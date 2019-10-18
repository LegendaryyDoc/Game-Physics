using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public Collider trigger;
    public string textShown = "No Text";
    public Text text;

    [HideInInspector] public bool trig = false;

    private void OnTriggerEnter(Collider other)
    {
        trig = true;
        text.text = textShown;
        text.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trig = false;
        text.enabled = false;
    }
}
