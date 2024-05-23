using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public GameObject thisSphere;
    public Material originalMaterial;
    public Material transparentMaterial;
    public float frequency;
    private float timePassed;
    private bool transparent;

    // Flickering the object on and off 

    void Start(){
        timePassed = 0.0f;
        transparent = false;
    
    }


    void SwitchMesh(bool isEnabled){
        thisSphere.GetComponent<MeshRenderer>().enabled = isEnabled;
    }

    void FixedUpdate()
    {
        timePassed += Time.fixedDeltaTime;
        if (timePassed >= 1/frequency) //Assumption: in seconds
        {
            timePassed = 0.0f;
            if (transparent)
                {
 
                    SwitchMesh(true);
                    transparent = false;
                }
            else
            {

                SwitchMesh(false);
                transparent = true;
            }
        }
    

    }
}

