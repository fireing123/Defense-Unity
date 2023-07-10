using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCManger : MonoBehaviour
{
    void FixedUpdate()
    {

        if (Time.frameCount % 30 > 15) System.GC.Collect();
    }
}
