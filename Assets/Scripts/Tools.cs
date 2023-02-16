using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    public static float VerticalDistance(Vector3 v1,Vector3 v2)
    {
        var dis = (new Vector3(v1.x, 0, v1.z) - new Vector3(v2.x, 0, v2.z)).magnitude;
        return dis;
    }
}
