﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]public CharacterController cc;

    public Camera main;
    public float speed = 6;
    public float jumpSpeed = 8;
    public float gravity = 20;
    public float rotateSpeed = 2.0f;

    private Animation anim;
    private Rigidbody[] mesh;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
        mesh = GetComponentsInChildren<Rigidbody>();
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
                foreach(Rigidbody rb in mesh)
                {
                    rb.velocity = cc.velocity;
                }
                moveDirection.y = jumpSpeed;
            }
        }
        if(!cc.isGrounded)
        {
            //cc.GetComponent<Collider>().transform.position = mesh.transform.position;
            anim.enabled = false;
        }
        //Vector3 camera = transform.position;
        //main.transform.position = new Vector3(camera.x, 6, camera.z);
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
