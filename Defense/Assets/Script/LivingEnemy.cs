using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class LivingEnemy : MonoBehaviour
    {
        public Animator animator;
        public Vector3 nextDirection;
        public int speed;
        public int attackPower;

        public virtual void Awake()
        {

        }

        public virtual void Update()
        {
            MoveLoad();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("load")) return;
            
            transform.position = other.transform.position;
            Load load = other.GetComponent<Load>();
            nextDirection = -load.nodeDirection / 360;
            animator.SetBool("walk", true);

        }

        public virtual void AttackCastle(Collider collider)
        {
            collider.GetComponent<Castle>().HPDrmove(attackPower);
        }

        public virtual void MoveLoad()
        {
            transform.position += nextDirection * speed;
        }


    }


}