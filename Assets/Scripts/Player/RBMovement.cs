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
        //Debug.DrawRay(transform.position, Vector3.down);
        //float dist = .1f;
        //if (Physics.CheckCapsule(transform.position, Vector3.down, dist))
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;
        //}
        RaycastHit ray;
        if(Physics.Raycast(transform.position,Vector3.down,out ray))
        {
            if(ray.transform.tag == ("Floor"))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        if (isGrounded)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            anim.enabled = true;
            Debug.Log(anim.enabled);
            rb.useGravity = false;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anim.Play("Run");
            }
            else
            {
                anim.Play("Idle");
            }


          

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, 20, rb.velocity.z);
            }


            Vector3 movementVec = new Vector3(0, 0, v);
            movementVec = transform.TransformDirection(movementVec);
            movementVec = movementVec.normalized * speed * Time.deltaTime;
            rb.MovePosition(transform.position + movementVec);



            Quaternion newRot = Quaternion.Euler(gameObject.transform.rotation.x, h * speed, gameObject.transform.rotation.z);
            rb.MoveRotation(rb.rotation * newRot.normalized);
        }
            if (isGrounded == false)
            {
                anim.enabled = false; rb.useGravity = true; Debug.Log("Floating");
            }
    }
   
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.transform.tag == ("Floor"))
    //    {
    //    isGrounded = true;
    //    Debug.Log("Grounded");
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.tag != ("Floor"))
    //    {
    //        isGrounded = false;
    //        Debug.Log("Grounded");
    //    }

    //}
    
}
