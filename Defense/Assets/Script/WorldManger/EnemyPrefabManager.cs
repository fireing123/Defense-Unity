using Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace EnemyEntity
{

    public class EnemyPrefabManager : PrefabManger<EnemyPrefabData>
    {

        private Dictionary<string, GameObject> enemyPrefabs;

        private void Awake()
        {
            LoadEnemyPrefabs();
        }

        private void LoadEnemyPrefabs()
        {
            EnemyPrefabData prefabData = LoadPrefab();

            enemyPrefabs = new Dictionary<string, GameObject>();

            foreach (EnemyPrefabInfo enemyInfo in prefabData.enemies)
            {
                GameObject prefab = Resources.Load<GameObject>(enemyInfo.prefabPath);
                
                if (prefab != null)  
                enemyPrefabs.Add(enemyInfo.name, prefab); 

                else  
                Debug.LogWarning("Failed to load prefab: " + enemyInfo.name); 
            }
        }

        

        public GameObject GetPrefab(string _name)
        {
            bool _isHas = enemyPrefabs.TryGetValue(_name, out GameObject prefab);

            if (_isHas)
            {
                return Instantiate(prefab);
            }
            Debug.LogWarning("Enemy prefab not found: " + _name);
            return null;
        }
    }
}
