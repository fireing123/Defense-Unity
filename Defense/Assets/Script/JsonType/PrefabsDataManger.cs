using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [System.Serializable]
    public class EnemyPrefabInfo
    {
        public string name;
        public string prefabPath;
    }

    [System.Serializable]
    public class EnemyPrefabData
    {
        public List<EnemyPrefabInfo> enemies;
    }
}

