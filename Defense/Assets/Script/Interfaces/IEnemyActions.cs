

using System.Collections;
using UnityEngine;

namespace Enemy
{
    public interface IEnemyActions
    {
        IEnumerator AttackAt(GameObject @gameObject);
    }
}