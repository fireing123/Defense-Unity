using Enemy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity
{

    public class AllyEnitiy : MonoBehaviour
    {
        public int cooldown;
        public int attackPower;
        public int id;
        

        public GameObject isfocus;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (isfocus == null) { isfocus = other.gameObject; }
                var enemy = other.GetComponent<LivingEnemy>();
                try
                {
                    if (enemy.coodown[id] <= 0 && isfocus == other.gameObject)
                    {
                        enemy.coodown[id] = cooldown;
                        enemy.HP -= attackPower;
                    }
                } catch (Exception e)
                {
                    Debug.Log(e.ToString());
                    enemy.coodown.Add(cooldown);
                }

                
            }
        }

    }
}
