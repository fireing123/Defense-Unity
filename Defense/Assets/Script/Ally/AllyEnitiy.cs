
using EnemyEntity;
using System;
using UnityEngine;

namespace AllyEntity
{

    public class AllyEnitiy : MonoBehaviour
    {
        public ushort cooldown;
        public byte physicalAttackPower;
        public byte magicAttackPower;
        public byte id;
        public byte Price;
        public Animator animator;

        public GameObject isfocus;


        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;

            if (isfocus ==null)
            {
                isfocus = other.gameObject;
            }

            try
            {
                if (other.TryGetComponent(out LivingEnemy enemy)) throw new Exception("This enemy undefined LivingEnemy component");

                if (enemy?.coodown[id] == null)
                {
                    enemy.coodown.Add(cooldown);
                }
                else if (enemy.coodown[id] <= 0 && isfocus == other.gameObject)
                {
                    Attack(enemy);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            var tr = GetComponentsInChildren<Transform>()[1];
            tr.rotation = LookAt(other.transform.position - tr.position);
        }

        public void Attack(LivingEnemy _gameObject)
        {
            animator.SetTrigger("Attack");
            _gameObject.SetCooldown(cooldown, id);
            _gameObject.attacked(physicalAttackPower, magicAttackPower);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == isfocus)
            {
                isfocus = null;

            }

        }

        public Quaternion LookAt(Vector3 direction)
        {
            return Quaternion.LookRotation(direction);
        }
    }
}
