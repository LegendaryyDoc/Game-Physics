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
    private float randStart;
    private float current;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPos = gameObject.transform.position;
        endPos = gameObject.transform.position + distanceAway;
        target = endPos;
        randStart = Random.Range(1, 4);
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        current += 1 * Time.deltaTime;
            if (gameObject.transform.position == endPos)
            {
                if (current > randStart)
                {
                target = startPos;
                current = 0;
                }
            }
            else if (gameObject.transform.position == startPos)
            {
                target = endPos;
            }

            transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed);
        
    }
  
}
