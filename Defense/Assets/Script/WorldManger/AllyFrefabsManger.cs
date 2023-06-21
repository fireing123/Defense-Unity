using Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFrefabsManger : MonoBehaviour
{

    public TextAsset allyPrefabsJson;
    public Dictionary<string, GameObject> allyPrefabs;

    void Awake()
    {
        LoadAllyEntity();
    }
    
    public void LoadAllyEntity()
    {
        AllyPrefabsData _allyPrefabs = JsonUtility.FromJson<AllyPrefabsData>(allyPrefabsJson.text);
    
        allyPrefabs = new Dictionary<string, GameObject>();

        foreach (AllyPrefabsInfo prefabsInfo in _allyPrefabs.allyies)
        {
            GameObject prefab = Resources.Load<GameObject>(prefabsInfo.prefabPath);
            if (prefab != null)
            {
                allyPrefabs.Add(prefabsInfo.name, prefab);
            }
            else
            {
                Debug.LogWarning("Failed to load prefab: " + prefabsInfo.name);
            }
        }

    }
}
