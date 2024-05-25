using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_LifePop : MonoBehaviour
{
    private sungchan3100_BossHead bossHead;
    // Start is called before the first frame update
    void Start()
    {
        bossHead = GameObject.Find("BossHead").GetComponent<sungchan3100_BossHead>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHead.LifeDown();
            Destroy(gameObject);
        }
    }
}
