using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]public CharacterController cc;

    public float speed = 6;
    public float jumpSpeed = 8;
    public float gravity = 20;
    public float rotateSpeed = 2.0f;
    public bool isJumping = false;

    private Vector3 moveDirection = Vector3.zero;

    private Animation anim;

    private Rigidbody[] rigidbodies;

    private PlayerAlive playerAlive;


    void Start()
    {
        cc = GetComponent<CharacterController>();

        anim = GetComponent<Animation>();

        rigidbodies = GetComponentsInChildren<Rigidbody>();

        playerAlive = GetComponent<PlayerAlive>();
    }



    void Update()
    {
        // Update functions only run if Character is alive.
        if (playerAlive.isAlive.Equals(true))
        {
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
       // Movement and Jump only available when the character controller is grounded.
        if (cc.isGrounded)            
        {
            anim.enabled = true;

            isJumping = false;

            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.Space) || Input.anyKey && Input.GetKey(KeyCode.Space))
            {
                    isJumping = true;
                moveDirection.y = jumpSpeed;
            }
            
        }
        // disabling animation to enable ragdoll when not grounded.
        if(!cc.isGrounded && isJumping.Equals(true))
        {
                anim.Stop();
        }
            moveDirection.y -= gravity * Time.deltaTime;
            cc.Move(moveDirection * Time.deltaTime);
        

        // if/else to display different animations.
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.Play("Run");
        }
        else if(!Input.anyKey && isJumping.Equals(false))
        {
            anim.Play("Idle");
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed,0);
        }
        // Enables Ragdoll on death.
        else
        {
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }
    }
    
}
