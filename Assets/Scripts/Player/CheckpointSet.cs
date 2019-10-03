using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerAlive>().spawnPoint = gameObject.transform.position;
        }
    }
}
