using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_DestPoint : MonoBehaviour
{
    public GameObject movingObject;
    private sungchan3100_MoveTwoDestination movingScript;
    // Start is called before the first frame update
    void Start()
    {
        movingScript = movingObject.GetComponent<sungchan3100_MoveTwoDestination>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (movingObject.gameObject == collision.gameObject)
        {
            movingScript.DestinationReached();
        }
    }
}
