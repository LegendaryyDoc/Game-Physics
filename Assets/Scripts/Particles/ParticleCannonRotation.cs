using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCannonRotation : MonoBehaviour
{
    public ParticleSystem pSystem;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = pSystem.transform.rotation;
    }
}
