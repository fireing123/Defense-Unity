using System.Threading.Tasks;
using UnityEngine;

namespace EnemyEntity
{
    interface ISpawnWave
    {
        void SpawnWave(Transform father, Vector3 position, float waitSec);
    }
}