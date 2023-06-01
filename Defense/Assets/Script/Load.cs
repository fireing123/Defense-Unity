using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    public Transform nextNode;

    public Vector3 nodeDirection;

    public virtual void Awake()
    {
        if (gameObject.transform == nextNode) { nodeDirection = new Vector3(0, 0, 0); return; }
        gameObject.tag = "load";
        var Direction = transform.position - nextNode.position;
        nodeDirection = Direction / Vector3.Distance(transform.position , nextNode.position);
    }

    public virtual void Update()
    {
    }
}
