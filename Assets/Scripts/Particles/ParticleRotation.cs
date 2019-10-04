using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour
{
    public Vector3 maxRotation = new Vector3(0,0,20);
    public Vector3 minRotation = new Vector3(0,0,0);
    public ParticleSystem pSystem;
    public float rotateSpeed = 1;

    private float rotationChange;

    private void Start()
    {
        Debug.Log(pSystem.transform.rotation);
        if(pSystem.transform.rotation.z - maxRotation.z > pSystem.transform.rotation.z - minRotation.z)
        {
            rotationChange = rotateSpeed;
        }
        else
        {
            rotationChange = -rotateSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pSystem.transform.rotation);

        if (pSystem.transform.rotation.z > maxRotation.z)
        {
            rotationChange = -rotateSpeed;
        }
        else if(pSystem.transform.rotation.z < minRotation.z)
        {
            rotationChange = rotateSpeed;
        }

        pSystem.transform.rotation = new Quaternion(pSystem.transform.rotation.x, pSystem.transform.rotation.y, (pSystem.transform.rotation.z + (rotationChange * Time.deltaTime)), 1);
    }
}