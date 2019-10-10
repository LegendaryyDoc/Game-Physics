using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour
{
    public Vector3 maxRotation = new Vector3(20,0,0);
    public Vector3 minRotation = new Vector3(0,0,0);
    public ParticleSystem pSystem;
    public float rotateSpeed = 1;

    private Vector3 euler;
    private float rotationChange;
    private Quaternion rotMax;
    private Quaternion rotMin;

    private void Start()
    {
        rotMax = Quaternion.Euler(maxRotation);
        rotMin = Quaternion.Euler(minRotation);

        euler = new Vector3((rotateSpeed), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (pSystem.transform.rotation.x >= rotMax.x)
        {
            euler.x = -rotateSpeed;
        }
        else if(pSystem.transform.rotation.eulerAngles.x <= rotMin.x)
        {
            euler.x = rotateSpeed;
        }

        pSystem.transform.Rotate(euler * Time.deltaTime, Space.World);
    }
}