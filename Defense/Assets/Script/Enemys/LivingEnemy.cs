
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Load;

namespace EnemyEntity
{
    public class LivingEnemy : MonoBehaviour, IEnemyActions
    {
        public Animator animator;
        public Vector3 nextDirection;
        public int HP;
        public int speed;
        public int attackPower;
        public float attackTime;
        public bool move;
        public List<int> coodown = new();


        public virtual void FixedUpdate()
        {
            if (move) MoveLoad();
            TimeCooldwon();
            if (!IsLiving()) Die();
        }

        public void OnTriggerEnter(Collider other)
        {
            LoadNode load = other.GetComponent<LoadNode>();

            Debug.Log(load?.types);

            if (other.CompareTag("load"))
            {
                
                if (load.types == LoadTypes.AllyCastle)
                {
                    move = false;
                    animator.SetBool("Walk", false);
                    animator.SetTrigger("Attack");
                    StartCoroutine(AttackAt(other.gameObject));

                }
                else {
                    transform.position = other.transform.position;

                    move = true;
                    nextDirection = -load.nodeDirection;

                    transform.rotation = LookAt(nextDirection);
                    animator.SetBool("Walk", true);
                }
            }
        }
        void Die()
        {
            Destroy(gameObject);
        }

        bool IsLiving()
        {
            return HP > 0;
        }

        void TimeCooldwon()
        {
            for (int i = 0; i < coodown.Count; i++)
            {
                if (coodown[i] > 0)
                {
                    coodown[i] -= 1;
                }
            }
        }

        public Quaternion LookAt(Vector3 direction)
        {
            return Quaternion.LookRotation(direction);
        }

        protected virtual void MoveLoad()
        {
            transform.position += nextDirection * speed / 120;
        }

        public IEnumerator AttackAt(GameObject @Object)
        {
            yield return new WaitForSeconds(attackTime);
            Castle castle = @Object.GetComponent<Castle>();
            castle.HPDrmove(attackPower);
            Destroy(gameObject);
        }
    }


}