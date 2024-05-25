using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_Bullet : MonoBehaviour
{
    public float fireForce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Initiate();
    }

    public void Fire(Vector3 direction)
    {
        rb.AddForce(direction.normalized * fireForce, ForceMode2D.Impulse);
    }

    public void Initiate()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
