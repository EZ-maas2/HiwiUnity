using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System;

public static class RayPosTracker 
{
    private static Vector3 _pos;
    public static event  Action<Vector3>  NotifyPos;
    public static Vector3 position {
        get { return _pos;}
        set {
            _pos = value;
            NotifyPos?.Invoke(_pos);


        }
    }
}
