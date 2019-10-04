using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlive : MonoBehaviour
{
    private MeshRenderer player;
    private Movement movement;

    public bool isAlive;
    public Vector3 spawnPoint;

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
            movement.enabled = false;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.transform.position = spawnPoint;

            isAlive = !isAlive;
            movement.enabled = true;
        }
    }
}