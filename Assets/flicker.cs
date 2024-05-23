using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public GameObject thisSphere;
    public Material originalMaterial;
    public Material transparentMaterial;
    public int frequency;
    private float timePassed;
    private bool transparent;

    // Flickering the object on and off 

    void Start(){
        timePassed = 0.0f;
        transparent = false;
    
    }

    void SwitchMaterial(Material material){
        thisSphere.GetComponent<Renderer>().material= material;
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
                    //SwitchMaterial(originalMaterial);
                    SwitchMesh(true);
                    transparent = false;
                }
            else
            {
                //SwitchMaterial(transparentMaterial);
                SwitchMesh(false);
                transparent = true;
            }
        }
    

    }
}

