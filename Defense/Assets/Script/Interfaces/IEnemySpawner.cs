using UnityEngine;

namespace EnemyEntity
{
    public interface IEnemySpawner
    {
        GameObject SpawnEnemy(string name);
    }
}