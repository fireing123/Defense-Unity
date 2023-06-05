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
            if (load.nextNode != other.transform)
            {
                nextDirection = -load.nodeDirection / 360;
            }
            else
            {
                animator.SetTrigger("Attack");
            }
        }

        public virtual void AttackCastle(Collider collider)
        {
            collider.GetComponent<Castle>().HPDrmove(attackPower);
        }

        public virtual void MoveLoad()
        {
            transform.Translate(nextDirection * speed);
        }


    }


}