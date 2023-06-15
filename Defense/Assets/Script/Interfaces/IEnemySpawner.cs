


using System.Collections;
using UnityEngine;

namespace Enemy
{
    public interface IEnemySpawner
    {
        IEnumerator SpawnEnemy(string name, Transform fatherTransform, Vector3 position, float WaitSecond);
    }
}