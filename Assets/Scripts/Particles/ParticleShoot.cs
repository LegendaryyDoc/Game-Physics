using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShoot : MonoBehaviour
{
    public float fireTime;

    private ParticleSystem pSystem;

    // Start is called before the first frame update
    void Start()
    {
        pSystem = transform.GetComponent<ParticleSystem>();
        pSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pSystem.Play();
        }
    }
}
