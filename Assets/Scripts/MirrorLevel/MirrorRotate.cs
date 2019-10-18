using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotate : MonoBehaviour
{
    public float rotateSpeed = 1;
    public InteractableObjects IO;

    // Update is called once per frame
    void Update()
    {

        if (IO.trig == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + rotateSpeed * Time.deltaTime, transform.rotation.z, transform.rotation.w);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y - rotateSpeed * Time.deltaTime, transform.rotation.z, transform.rotation.w);
            }
        }
    }
}