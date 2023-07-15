using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllyEntity
{
    [System.Serializable]
    public class AllySelectData
    {
        public List<AllySelectInfo> allys;
    }

    [System.Serializable]
    public class AllySelectInfo
    {
        public string name;
        public string photo;
        public string objectPath;
    }
}