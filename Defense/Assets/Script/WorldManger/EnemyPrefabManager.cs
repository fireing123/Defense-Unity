using Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace EnemyEntity
{
    [System.Serializable]
    public class EnemyPrefabManager : PrefabManger<EnemyPrefabData>
    {

        private static Dictionary<string, GameObject> enemyPrefabs;

        public static void LoadEnemyPrefabs(TextAsset JsonText)
        {
            EnemyPrefabData prefabData = LoadPrefab(JsonText.text);

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

        

        public static GameObject GetPrefab(string _name)
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
