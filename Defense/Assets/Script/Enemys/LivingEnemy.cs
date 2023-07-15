
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
        public Vector3 prev;

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
            bool isLoad = other.TryGetComponent(out LoadNode load);

            if (isLoad)
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
                    prev = nextDirection * speed / 120;
                    transform.rotation = LookAt(nextDirection);
                    animator.SetBool("Walk", true);
                }
            }
        }

        public void attacked(byte phyPower, byte magPower)
        {
            HP -= phyPower / physicalDefense;
            HP -= magPower / magicDefense;
        }

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
            transform.position += prev;
        }

        public IEnumerator AttackAt(GameObject @Object)
        {
            yield return new WaitForSeconds(attackTime);
            @Object.TryGetComponent(out Castle castle);
            castle.HPDrmove(attackPower);
            Destroy(gameObject);
        }
    }


}