using System.Threading.Tasks;
using UnityEngine;

namespace Enemy
{
    interface ISpawnWave
    {
        void SpawnWave(Transform father, Vector3 position, float waitSec);
    }
}