using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
