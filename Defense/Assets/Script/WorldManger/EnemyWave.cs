using Prefab;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace EnemyEntity
{
    public class EnemyWave : PrefabManger<WavesData>, IEnemySpawner, ISpawnWave
    {

        public bool isWaving;
        public string waveName;
        private int waveid=-1;
        public Dictionary<string, string[]> enemyWaves = new();

        public EnemyPrefabManager EnemyPrefabManager;

        void Awake()
        {
            TryGetComponent(out EnemyPrefabManager);
            LoadEnemyWaves();
        }

        public bool UpdateWave()
        {
            var list = new List<string>(enemyWaves.Keys);
            if (list.Count <= waveid + 1)
            {
                return false;
            } else {
                waveid += 1;
                waveName = list[waveid];
                return true;
            }
        }

        public async void SpawnWave(Transform father ,Vector3 position, float waitSec)
        {
            if (!enemyWaves.TryGetValue(waveName, out string[] wave))
            {
                throw new System.Exception("wave no ");
            }

            foreach (string waveObjectName in wave)
            {
                
                var gameObject = SpawnEnemy(waveObjectName);

                gameObject.transform.position = position;
                gameObject.transform.parent = father;
                await Task.Delay(2000);
            }

        }

        public GameObject SpawnEnemy(string _enemyName) => EnemyPrefabManager.GetPrefab(_enemyName);


        public void LoadEnemyWaves()
        {
            WavesData waves = LoadPrefab();
            
            foreach (Wavesinfo wave in waves.level)
            {
                enemyWaves.Add(wave.name, wave.enemys);
            }
        }
    }
}
