using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Vector3 nextDirection;
    public int speed;

    public virtual void Start()
    {
    
    }

    public virtual void Update()
    {
       MoveLoad();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("load")) return;
        
        transform.position = other.transform.position;
        Load load = other.GetComponent<Load>();
        if (load.nextNode!=other.transform)
        {
            nextDirection = -load.nodeDirection / 360;
        } else
        {
           AttackCastle(other);
        }
    }

    public virtual void AttackCastle(Collider collider)
    {
        Destroy(gameObject);
        collider.GetComponent<Castle>().HPDrmove(5);
    }

    public virtual void MoveLoad()
    {
        transform.Translate(nextDirection * speed);
    }



}

