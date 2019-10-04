using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMovement : MonoBehaviour
{
    public bool isGrounded = true;
    public float speed = 4;
    Rigidbody rb;
    Animation anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
       
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDist + 0.1f);
    }

    void Update()
    {
        Collider groundDist = GetComponent<Collider>();
        float dist = 1;
        if (Physics.Raycast(groundDist.transform.position, Vector3.down, dist))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        if (isGrounded)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            anim.enabled = true;
            rb.useGravity = false;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anim.Play("Run");
            }
            else
            {
                anim.Play("Idle");
            }


            if (isGrounded == false) { anim.enabled = false; rb.useGravity = true; Debug.Log("Floating"); }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0,10,0, ForceMode.Impulse);

            }
            Vector3 movementVec = new Vector3(0, 0, v);
            movementVec = transform.TransformDirection(movementVec);
            movementVec = movementVec.normalized * speed * Time.deltaTime;
            Quaternion newRot = Quaternion.Euler(gameObject.transform.rotation.x, h * speed, gameObject.transform.rotation.z);

            rb.MoveRotation(rb.rotation * newRot.normalized);
            rb.MovePosition(transform.position + movementVec);
        }
    }
}
