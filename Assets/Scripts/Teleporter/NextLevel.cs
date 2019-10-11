using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject nextLevel;

    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            Movement move = player.transform.root.GetComponent<Movement>();
            CharacterController cc = player.transform.root.GetComponent<CharacterController>();

            // make player do a teleport visual effect
            // make player pop out of existance
            player.gameObject.SetActive(false);

            // disable player movement and reset its movement
            move.enabled = false;
            cc.velocity.Set(0, 0, 0);

            // teleport the player to the next location with a visual effect for coming in
            player.transform.position = nextLevel.transform.position;
            player.gameObject.SetActive(true);

            // enabled player movement
            move.enabled = true;
        }
    }
}