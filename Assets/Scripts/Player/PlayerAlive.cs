﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAlive : MonoBehaviour
{
    public Text LoseText;
    public bool isAlive;
    public Vector3 spawnPoint;
    public int health = 3;
    public Text healthBar;

    private Rigidbody rb;
    private MeshRenderer player;
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true; 
        movement = gameObject.GetComponent<Movement>();
        player = gameObject.GetComponent<MeshRenderer>();
        rb = movement.gameObject.GetComponent<Rigidbody>();
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.text = "Health:" + health.ToString();
        if(!isAlive)
        {
            if (health > 0) // player respawn at last checkpoint
            {
                movement.enabled = false;
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                gameObject.transform.position = spawnPoint;
                rb.velocity = Vector3.zero;
                isAlive = !isAlive;
                movement.enabled = true;
            }
            else if(health <= 0) // player death
            {
                // disabled player movement

                // disable animations on player so can ragdoll
                gameObject.GetComponent<Animation>().enabled = false;

                // trigger death event

                LoseText.text = "You Died!";
            }
        }
    }
}