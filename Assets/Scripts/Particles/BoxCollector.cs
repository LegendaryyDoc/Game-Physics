using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    public int targetNumberOfParticlesCollected = 10;
    public Material boxMeter;
    public Material boxSlime;

    private int currentNumberOfParticles = 0;
    private bool levelPass = false;
    private float startingLiquidDensity;
    private float startingSlimeDensity;

    private void Start()
    {
        levelPass = false;
        startingLiquidDensity = boxMeter.GetFloat("Vector1_EF725229");
        startingSlimeDensity = boxSlime.GetFloat("Vector1_806ECB9");
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("BoxCollector"))
        {
            ++currentNumberOfParticles;
            boxMeter.SetFloat("Vector1_EF725229", currentNumberOfParticles);
            boxSlime.SetFloat("Vector1_806ECB9", currentNumberOfParticles);

            if (currentNumberOfParticles >= targetNumberOfParticlesCollected)
            {
                levelPass = true;
            }
        }
    }

    private void OnApplicationQuit()
    {
        boxMeter.SetFloat("Vector1_EF725229", startingLiquidDensity);
        boxSlime.SetFloat("Vector1_806ECB9", startingSlimeDensity);
    }
}