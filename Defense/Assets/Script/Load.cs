using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    public Transform nextNode;

    public Vector3 nodeDirection;

    void Awake()
    {
        gameObject.tag = "load";
        var Direction = transform.position - nextNode.position;
        nodeDirection = Direction / Vector3.Distance(transform.position , nextNode.position);
    }

    void Update()
    {
    }
}
