using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController cc;
    Animation anim;
    public float speed = 6;
    public float jumpSpeed = 8;
    public float gravity = 20;
    public float rotateSpeed = 2.0f;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
    }



    void Update()
    {
        if (cc.isGrounded)
        {
            anim.enabled = true;
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                moveDirection.y = jumpSpeed;
            }
        }
        if(!cc.isGrounded)
        {
          anim.enabled = false;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.Play("Run");
            
        }
        else
        {
            anim.Play("Idle");
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed,0);
    }
}
