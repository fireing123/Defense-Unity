


using UnityEngine;

namespace Enemy
{
    public interface IEnemySpawner
    {
        GameObject SpawnEnemy(string name, Vector3 position);
    }
}