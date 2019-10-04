using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.transform.CompareTag("Player"))
        {
            PlayerAlive pl = collision.transform.root.gameObject.GetComponent<PlayerAlive>();

            Debug.Log("Checkpoint reached");
            pl.spawnPoint = gameObject.transform.position;
        }
    }
}