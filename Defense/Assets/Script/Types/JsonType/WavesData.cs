using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EnemyEntity
{

    [System.Serializable]
    public class Wavesinfo
    {
        public string name;
        public string[] enemys;
    }

    [System.Serializable]
    public class WavesData
    {
        public List<Wavesinfo> level;
    }
}
