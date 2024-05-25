using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_GoToward : MonoBehaviour
{
    private Vector3 toward;
    public float speed;
    private sungchan3100_GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<sungchan3100_GameManager>();
        Invoke("DestroySelf", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(toward * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir)
    {
        toward = dir.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
