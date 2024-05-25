using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_GoForward : MonoBehaviour
{
    public float speed;
    private sungchan3100_GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<sungchan3100_GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameActive()) transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
