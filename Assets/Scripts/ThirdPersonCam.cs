using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public float Speed = 5;
    public Transform Target;
    public Camera Cam;

    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector3 direction = (Target.position - Cam.transform.position).normalized;

        Quaternion lookrotation = Quaternion.LookRotation(direction);
        lookrotation.x = transform.rotation.x;
        lookrotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 100);

        transform.position = Vector3.Slerp(transform.position, Target.position, Time.deltaTime * Speed);

    }
}
