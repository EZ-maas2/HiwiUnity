using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_up : MonoBehaviour
{
    public float new_z;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0,new_z);
    }
}
