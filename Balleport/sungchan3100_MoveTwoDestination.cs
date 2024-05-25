using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_MoveTwoDestination : MonoBehaviour
{
    public GameObject destOne;
    public GameObject destTwo;
    public float speed;
    public float timeWait;
    private int dest = 0;
    private bool isReached = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dest == 0)
        {
            TranslateTo(destOne.transform.position - transform.position);
        }
        else if (dest == 2)
        {
            TranslateTo(destTwo.transform.position - transform.position);
        }
    }

    void TranslateTo(Vector3 direction)
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if (isReached)
        {
            isReached = false;
            ++dest;
            Invoke("NextDest", timeWait);
        }
    }

    void NextDest()
    {
        dest = (dest + 1) % 4;
    }

    public void DestinationReached() { isReached = true; }
}
