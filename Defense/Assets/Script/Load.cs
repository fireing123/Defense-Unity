using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    public int IntLoad;
    public Vector3[] LoadUnits;
    public Vector3[] Course;

    void Awake()
    {
        Transform[] LoadTransform = GetComponentsInChildren<Transform>();
        int LoadTransformLength = LoadTransform.Length;
        Vector3[] vector3s = new Vector3[LoadTransformLength];
        for(int i =0; i < LoadTransformLength; i++)
        {
            vector3s[i] = LoadTransform[i].position;
        }
        LoadUnits = vector3s;
        IntLoad = LoadUnits.Length;
    }

    void Update()
    {
    }

    private void GetCheckingWay()
    {

    }
}
