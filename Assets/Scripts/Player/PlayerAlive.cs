using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlive : MonoBehaviour
{
    public bool isAlive;
    public Vector3 spawnPoint;
    public int health = 3;

    private MeshRenderer player;
    private Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        movement = gameObject.GetComponent<Movement>();
        player = gameObject.GetComponent<MeshRenderer>();
        spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive)
        {
            if (health > 0) // player respawn at last checkpoint
            {
                movement.enabled = false;
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                gameObject.transform.position = spawnPoint;

                isAlive = !isAlive;
                movement.enabled = true;
            }
            else if(health <= 0) // player death
            {
                // disabled player movement
                gameObject.GetComponent<Movement>().enabled = false;

                // disable animations on player so can ragdoll
                gameObject.GetComponent<Animation>().enabled = false;

                // trigger death event
            }
        }
    }
}