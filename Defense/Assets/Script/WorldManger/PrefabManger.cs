using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prefab
{
    public class PrefabManger<TJsonData> : MonoBehaviour
    {
        public static TJsonData LoadPrefab(string json)
        {
            TJsonData jsonData = JsonUtility.FromJson<TJsonData>(json);
            return jsonData;
        }


    }
}