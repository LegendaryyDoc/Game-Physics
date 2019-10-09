using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSet : MonoBehaviour
{
    public Color checkPointReachedColor;
    public GameObject checkPoint;

    private Renderer cpMaterial;

    private void Start()
    {
        cpMaterial = checkPoint.GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.transform.CompareTag("Player"))
        {
            cpMaterial.material.SetColor("Color_2894C75A", checkPointReachedColor);
            PlayerAlive pl = collision.transform.root.gameObject.GetComponent<PlayerAlive>();

            Debug.Log("Checkpoint reached");
            pl.spawnPoint = gameObject.transform.position;
        }
    }
}