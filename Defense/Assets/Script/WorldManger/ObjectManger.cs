using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManger : MonoBehaviour
{
    private static byte nextId = 0;

    public static void IDEmpty()
    {
        nextId = 0;
    }

    public static byte GenerateUniqueId()
    {
        return nextId++;
    }
}
