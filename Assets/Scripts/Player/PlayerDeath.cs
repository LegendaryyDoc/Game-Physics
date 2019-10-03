using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
        if(collision.gameObject.transform.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerAlive>().isAlive == true)
            {
                Debug.Log("You Died");
                collision.gameObject.GetComponent<PlayerAlive>().isAlive = false;
            }
        }
   }
}