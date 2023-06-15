
using UnityEngine;
namespace Enemy
{
    interface ISpawnWave
    {
        GameObject SpawnWave(string waveName, string[] waveObjectNames, Vector3 position, float waitSec);
    }
}