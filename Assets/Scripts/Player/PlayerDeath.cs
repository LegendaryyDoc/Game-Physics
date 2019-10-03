using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.transform.CompareTag("Player"))
        {
            Debug.Log("You Died");
            collision.gameObject.GetComponent<PlayerAlive>().isAlive = false;
        }
   }
}