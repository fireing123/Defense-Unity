using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllyEntity
{
    [System.Serializable]
    public class AllyPrefabsData
    {
        public List<AllyPrefabsInfo> allies;
    }

    [System.Serializable]
    public class AllyPrefabsInfo
    {
        public string name;
        public string prefabPath;
    }

}