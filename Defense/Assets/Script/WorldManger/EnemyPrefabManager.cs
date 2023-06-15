using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static Enemy.EnemyPrefabData;
using static Enemy.EnemyPrefabInfo;

namespace Enemy
{

    public class EnemyPrefabManager : MonoBehaviour, IEnemySpawner, ISpawnWave
    {
        public LevelWaves waves;
        public int waveInt;
        public bool isWaveEnd;

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
                GameObject prefab = Resources.Load<GameObject>(enemyInfo.prefabPath);
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

        public GameObject SpawnWave(string waveName, string[] waveObjectNames, Vector3 position, float waitSec)
        {
            GameObject waveFather = new(waveName);

            foreach (string waveObjectName in waveObjectNames)
            {
                StartCoroutine(SpawnEnemy(
                    waveObjectName, 
                    waveFather.transform,
                    position,
                    waitSec));
            }
            return waveFather;
        }

        public IEnumerator SpawnEnemy(string _enemyName, Transform fatherTransform, Vector3 position, float WaitSecond)
        {
            var _enemyObject = GetPrefab(_enemyName);
            _enemyObject.transform.position = position;
            _enemyObject.transform.parent = fatherTransform;
            yield return new WaitForSeconds(WaitSecond);
        }

        public GameObject GetPrefab(string _name)
        {
            bool _isHas = enemyPrefabs.TryGetValue(name, out GameObject prefab);
            if (_isHas)
            {
                return Instantiate(prefab);
            }
            Debug.LogWarning("Enemy prefab not found: " + name);
            return null;
        }

        public int GetWaveInt()
        {
            return waveInt;
        }

        public GameObject UpdateWave(Vector3 castlePosition, float waitSec, int waveInt)
        {

            GameObject gameObject1 = SpawnWave("wave"+waveInt.ToString(), waves.evel[waveInt], castlePosition, waitSec);
            waveInt++;
            isWaveEnd = false;
            return gameObject1;
        }
    }


}
