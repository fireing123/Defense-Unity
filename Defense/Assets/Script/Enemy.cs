using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Vector3 nextDirection;
    public int speed;

    void Start()
    {
    
    }

    private void Update()
    {
        transform.Translate(nextDirection * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "load") return;
        
        transform.position = other.transform.position;
        Load load = other.GetComponent<Load>();
        if (load.nextNode!=other.transform)
        {
            nextDirection = -load.nodeDirection / 360;
        } else
        {
            Destroy(gameObject);
            other.GetComponent<Castle>().HPDrmove(5);
        }
    }

}

