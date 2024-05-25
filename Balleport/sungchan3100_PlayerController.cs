using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sungchan3100_PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private GameObject gunCenter;
    private sungchan3100_GameManager gameManager;
    private GameObject bullet;
    private GameObject gun;
    private sungchan3100_Bullet bulletScript;
    public ParticleSystem gameOverEffect;
    private bool onElevator = false;
    private GameObject elevator;
    private Vector3 lastElevPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gunCenter = GameObject.Find("GunCenter");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        gun = GameObject.Find("Gun");

        bulletScript = bullet.GetComponent<sungchan3100_Bullet>();
        bullet.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<sungchan3100_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onElevator)
        {
            transform.position += (elevator.transform.position - lastElevPos);
            lastElevPos = elevator.transform.position;
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        ProcessKeyCommands();
        if (transform.position.y < -10.0f)
        {
            gameManager.GameOver();
        }
    }

    private void ProcessKeyCommands()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isJumping)
        {
            isJumping = true;
            if (onElevator)
            {
                onElevator = false;
                Debug.Log("Jump On Ele");
                //transform.position += new Vector3(0.0f, 4.0f, 0.0f);
            }
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (bullet.gameObject.activeSelf)
            {
                onElevator = false;
                transform.position = bullet.transform.position;
                bullet.SetActive(false);
            }
            else
            {
                bullet.SetActive(true);
                bullet.transform.position = gun.transform.position;
                bulletScript.Fire(gun.transform.position - gunCenter.transform.position);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Elevator"))
        {
            isJumping = false;
            onElevator = true;
            elevator = collision.gameObject;
            lastElevPos = elevator.transform.position;
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            gameManager.Win();
        }
    }
}
