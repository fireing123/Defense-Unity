

using System.Collections;
using UnityEngine;

namespace EnemyEntity
{
    public interface IEnemyActions
    {
        IEnumerator AttackAt(GameObject @gameObject);
    }
}