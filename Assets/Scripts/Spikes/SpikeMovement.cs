using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed = 1;
    public Vector3 distanceAway;

    private Vector3 target;
    private Vector3 startPos;
    private Vector3 endPos;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPos = gameObject.transform.position;
        endPos = gameObject.transform.position + distanceAway;
        target = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position == endPos)
        {
            target = startPos;
        }
        else if(gameObject.transform.position == startPos)
        {
            target = endPos;
        }

        transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed);
    }
}
