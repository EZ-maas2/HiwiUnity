using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;

public class PositionRay : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject indication;
    public event Action<Vector3> NewPosition;
    public LineRenderer lineRenderer;
    private float rayLength = 10f;

    void Update()
    {
        Vector3 rayOrigin = thisObject.transform.position;
        Vector3 rayDirection = Vector3.down;

        Ray ray = new Ray(rayOrigin, rayDirection);
        lineRenderer.SetPosition(0, rayOrigin);
        lineRenderer.SetPosition(1, rayOrigin + rayDirection * rayLength); // Extend the line
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            SendCoordinatesOnHit(hit); // this is being sent to ZMQ script
        }
    }


    void SendCoordinatesOnHit(RaycastHit hit)
    {
    RayPosTracker.position = hit.point;

    if (hit.collider.gameObject.tag != "Indication")
    {
        Instantiate(indication, hit.point, Quaternion.identity); // this creates an indication object that visualizes where the ray has hit (unless it  hit another indication object )
    }
        
    }
}


