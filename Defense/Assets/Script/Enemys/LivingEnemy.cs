
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Load;


namespace EnemyEntity
{
    public class LivingEnemy : MonoBehaviour
    {
        public Animator animator;
        public Vector3 nextDirection;
        public Vector3 prev;

        [Header("Enemy Status")]
        public int MAX_HP = 200;
        public int HP = 200;
        public byte speed = 10;
        public byte attackPower = 5;
        public byte attackTime = 1;
        public float height = 0.8f;

        [Space(5)]
        public byte physicalDefense = 10;
        public byte magicDefense = 10;

        [Space(3)]
        public byte compensation;
        public bool move;
        public List<ushort> coodown = new();

        public HPBAR hpbar;

        private void Start()
        {
            TryGetComponent(out animator);
            hpbar = new HPBAR(gameObject.name);
        }

        public virtual void FixedUpdate()
        {
            if (move) MoveLoad();
            TimeCooldwon();
            if (!IsLiving()) Die();
            hpbar.TransformTrans(transform.position, height);
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
            int power = DamgeCalculate(phyPower, physicalDefense) + DamgeCalculate(magPower, magicDefense);
            if (power < HP) HP -= power;
            else HP = 0;
            hpbar.SetHP((float)HP / MAX_HP);
        }

        public int DamgeCalculate(byte Damge, byte Defense)
        {
            return Damge * 100 / (100 + Defense);
        }

        public void SetCooldown(ushort _cooldown, byte id)
        {
            coodown[id] = _cooldown;
        }

        void Die()
        {
            Destroy(gameObject);
            Destroy(hpbar.Bar);
            EventsManger.EnemyDeathEvent.Invoke(this);
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
            Die();
        }
    }


}