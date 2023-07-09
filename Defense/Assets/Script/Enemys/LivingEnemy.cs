
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

        [Header("Enemy Status")]
        public int HP;
        public byte speed;
        public byte attackPower;
        public byte attackTime;

        [Space(5)]

        public byte defense;
        public byte physicalDefense;
        public byte magicDefense;

        [Space(3)]

        public bool move;
        public List<ushort> coodown = new();


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
                
                if (load.types.Equals(LoadTypes.AllyCastle))
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

        public void attacked(byte power, bool isAD)
        {
            if (isAD)
            {
                HP -= power / physicalDefense;
            } else
            {
                HP -= power / magicDefense;
            }
        }

        public void PhysicalAttack(byte power) => attacked(power, true);

        public void MagicAttack(byte power) => attacked(power, false);

        

        public void SetCooldown(ushort _cooldown, byte id)
        {
            coodown[id] = _cooldown;
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