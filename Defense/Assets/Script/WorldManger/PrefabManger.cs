using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prefab
{
    public class PrefabManger<TJsonData> : MonoBehaviour
    {
        public TextAsset prefabJson;

        public TJsonData LoadPrefab()
        {
            TJsonData jsonData = JsonUtility.FromJson<TJsonData>(prefabJson.text);
            return jsonData;
        }

    }
}