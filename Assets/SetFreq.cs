using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFreq : MonoBehaviour
{

    public float newFreq;

    public void SetFrequency()
    {
        GameObject[] flickeringObjects = GameObject.FindGameObjectsWithTag("Flicker");
        foreach (GameObject flickeringObject in flickeringObjects)
        {
            flickeringObject.GetComponent<Flicker>().frequency  = newFreq;
        }
    }
}
