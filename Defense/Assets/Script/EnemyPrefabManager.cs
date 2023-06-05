using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Entity
{

    [System.Serializable]
    public class EnemyPrefabInfo
    {
        public string name;
        public string prefabPath;
    }

    [System.Serializable]
    public class EnemyPrefabData
    {
        public List<EnemyPrefabInfo> enemies;
    }

    public class EnemyPrefabManager : MonoBehaviour
    {
        public TextAsset enemyPrefabDataJson; 

        private Dictionary<string, GameObject> enemyPrefabs;

        private void Awake()
        {
            LoadEnemyPrefabs();
        }

        private void LoadEnemyPrefabs()
        {
            EnemyPrefabData prefabData = JsonUtility.FromJson<EnemyPrefabData>(enemyPrefabDataJson.text);

            enemyPrefabs = new Dictionary<string, GameObject>();

            foreach (EnemyPrefabInfo enemyInfo in prefabData.enemies)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/Cube");
                if (prefab != null)
                {
                    enemyPrefabs.Add(enemyInfo.name, prefab);
                }
                else
                {
                    Debug.LogWarning("Failed to load prefab: " + enemyInfo.name);
                }
            }
        }

        public GameObject SpawnEnemy(string enemyName, Vector3 position)
        {
            if (enemyPrefabs.TryGetValue(enemyName, out GameObject prefab))
            {
                GameObject enemyObject = Instantiate(prefab);

                enemyObject.transform.position = position;

                return enemyObject;
            }

            Debug.LogWarning("Enemy prefab not found: " + enemyName);
            return null;
        }
    }
}