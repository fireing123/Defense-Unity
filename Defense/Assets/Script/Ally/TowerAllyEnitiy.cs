
using EnemyEntity;
using System;
using UnityEngine;

namespace AllyEntity
{

    public class TowerAllyEnitiy : MonoBehaviour
    {
        public int cooldown;
        public int attackPower;
        public int id;
        public Animator animator;

        public GameObject isfocus;


        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;

            if (isfocus ==null)
            {
                isfocus = other.gameObject;
            } 

            LivingEnemy enemy = other.GetComponent<LivingEnemy>();
            try
            {
                if (enemy.coodown[id] <= 0 && isfocus == other.gameObject)
                {
                    animator.SetTrigger("Attack");
                    enemy.coodown[id] = cooldown;
                    enemy.HP -= attackPower;
                }
            }
            catch
            {
                enemy.coodown.Add(cooldown);
            }
            var tr = GetComponentsInChildren<Transform>()[1];
            tr.rotation = LookAt(other.transform.position - tr.position);
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
