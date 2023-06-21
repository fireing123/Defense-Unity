
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
        

        public GameObject isfocus;


        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy")) return;

            if (isfocus == null) isfocus = other.gameObject; 

            LivingEnemy enemy = other.GetComponent<LivingEnemy>();
            try
            {
                if (enemy.coodown[id] <= 0 && isfocus == other.gameObject)
                {
                    enemy.coodown[id] = cooldown;
                    enemy.HP -= attackPower;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
                enemy.coodown.Add(cooldown);
            }
        }
    }
}
