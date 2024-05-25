using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungchan3100_RotateGunCenter : MonoBehaviour
{
    public float rotateSpeed;
    private float upperBound = 60.0f;
    private Quaternion rotationUpperBound;
    private Quaternion rotationLowerBound;
    // Start is called before the first frame update
    void Start()
    {
        rotationLowerBound = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        rotationUpperBound = Quaternion.Euler(new Vector3(0.0f, 0.0f, upperBound));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed * Input.GetAxis("Vertical"));
        if (transform.rotation.z < 0.0f) transform.rotation = rotationLowerBound;
        else if (transform.rotation.z > rotationUpperBound.z)
        {
            Debug.Log("60.0f");
            transform.rotation = rotationUpperBound;
        }
    }
}
