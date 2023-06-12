
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Load;

namespace Enemy
{
    public class LivingEnemy : MonoBehaviour, IEnemyActions
    {
        public Animator animator;
        public Vector3 nextDirection;
        public int HP;
        public int speed;
        public int attackPower;

        public virtual void Update()
        {
            if (animator)
            MoveLoad();
        }

        public void OnTriggerEnter(Collider other)
        {
            LoadNode load = other.GetComponent<LoadNode>();

            transform.position = other.transform.position;

            if (load.types == LoadTypes.AllyCastle)
            {
                animator.SetBool("Attacks", true);
            } else
            {
                nextDirection = -load.nodeDirection;

                transform.rotation = LookAt(nextDirection);
                animator.SetBool("Walk", true);
            }
        }

        public Quaternion LookAt(Vector3 direction)
        {
            return Quaternion.LookRotation(direction);
        }

        protected virtual void MoveLoad()
        {
            transform.position += nextDirection * speed / 360;
        }

        public void AttackFormName(string name)
        {
            try { 
                GameObject target = GameObject.Find(name);
                Castle castle = target.GetComponent<Castle>();
                castle.HPDrmove(attackPower);
            }
            catch (Exception e) { Debug.LogError(e); }
            
        }
    }


}