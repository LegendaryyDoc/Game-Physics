using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
        {
            PlayerAlive pl = collision.transform.root.gameObject.GetComponent<PlayerAlive>();

            if (pl.isAlive == true)
            {
                Debug.Log("Dead");
                pl.isAlive = false;
                pl.health -= 1;
            }
        }
    }
}