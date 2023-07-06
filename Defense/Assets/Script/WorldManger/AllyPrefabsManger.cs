using Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllyEntity
{
    public class AllyPrefabsManger : PrefabManger<AllyPrefabsData>
    {

        public Dictionary<string, GameObject> allyPrefabs = new();

        void Awake()
        {
            LoadAllyEntity();
        }

        public void LoadAllyEntity()
        {
            AllyPrefabsData allyPrefabsData = LoadPrefab();

            foreach (AllyPrefabsInfo prefabsInfo in allyPrefabsData.allies)
            {
                GameObject prefab = Resources.Load<GameObject>(prefabsInfo.prefabPath);

                if (prefab != null)
                allyPrefabs.Add(prefabsInfo.name, prefab);

                else
                Debug.LogWarning("Failed to load prefab: " + prefabsInfo.name);
            }

        }
    }
}