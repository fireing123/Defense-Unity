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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("gfgf");
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("gg");
        if (other.tag != "load") return;
        transform.position = other.transform.position;
        nextDirection = - other.GetComponent<Load>().nodeDirection / 360;
    }

}

