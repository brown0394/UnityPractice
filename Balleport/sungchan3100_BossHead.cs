using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sungchan3100_BossHead : MonoBehaviour
{
    private GameObject player;
    public GameObject projectile;
    public GameObject lifePrefab;
    public GameObject Wall;
    public float cooldown;
    public float repeatCool;
    public float life = 3;
    public float offsetY;
    public float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        for (int i = 0; i < life; ++i)
        {
            Instantiate(lifePrefab, GetRandomSpawnPos(), lifePrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector3 GetRandomSpawnPos()
    {
        return new Vector3(Random.Range(transform.position.x - offsetX, transform.position.x + offsetX),
            Random.Range(transform.position.y - offsetY, transform.position.y));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            InvokeRepeating("Attack", 0.0f, cooldown);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            CancelInvoke();
        }
    }

    void Attack()
    {
        Invoke("LaunchAttack", repeatCool);
        Invoke("LaunchAttack", repeatCool * 2);
        Invoke("LaunchAttack", repeatCool * 3);
    }

    void LaunchAttack()
    {
        GameObject pj = Instantiate(projectile, transform.position, Quaternion.Euler(player.transform.position - transform.position));
        pj.GetComponent<sungchan3100_GoToward>().SetDirection(player.transform.position - transform.position);
    }

    public void LifeDown()
    {
        --life;
        if (life == 0)
        {
            CancelInvoke();
            Destroy(gameObject);
            Destroy(Wall);
        }
    }
}
