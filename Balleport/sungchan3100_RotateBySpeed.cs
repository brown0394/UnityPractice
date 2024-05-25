using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sungchan3100_RotateBySpeed : MonoBehaviour
{
    public float rotateSpeed;
    public float rotateTo;
    private bool start = false;
    private Quaternion rotationDest;
    // Start is called before the first frame update
    void Start()
    {
        rotationDest = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotateTo));
        Debug.Log(rotationDest.z);
        Debug.Log(transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (rotationDest.z < 0.0f)
            {
                transform.Rotate(Vector3.forward, -1 * rotateSpeed * Time.deltaTime);
                if (rotationDest.z >= transform.rotation.z) start = false;
            }
            else if (rotationDest.z >= 0.0f)
            {
                transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
                if (rotationDest.z <= transform.rotation.z) start = false;
            }
        }
    }

    public void StartRotation()
    {
        start = true;
    }

    public bool IsRotationComplete()
    {
        if (rotationDest.z < 0.0f)
        {
            return transform.rotation.z <= rotationDest.z;
        }
        return transform.rotation.z >= rotationDest.z;
    }
}
