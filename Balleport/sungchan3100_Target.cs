using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_Target : MonoBehaviour
{
    sungchan3100_RotateBySpeed rotateScript;
    public GameObject rotator;
    private bool rotationStarted = false;
    public GameObject objectToTrigger;
    // Start is called before the first frame update
    void Start()
    {
        rotateScript = rotator.GetComponent<sungchan3100_RotateBySpeed>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotationStarted && rotateScript.IsRotationComplete())
        {
            rotationStarted = false;
            objectToTrigger.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            rotateScript.StartRotation();
            rotationStarted = true;
        }
    }
}
