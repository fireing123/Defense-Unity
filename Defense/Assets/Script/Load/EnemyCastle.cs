


using UnityEngine;

namespace EnemyEntity
{
    public class EnemyCastle : Castle
    {

        public EnemyWave level;

        [SerializeField]
        private GameObject waveFather;

        void Start()
        {
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();

            if (!level.isWaving && level.UpdateWave())
            {
                level.isWaving = true;
                waveFather = new(level.waveName);
                level.SpawnWave(waveFather.transform, transform.position, 2f);

            } else if (waveFather.GetComponentsInChildren<Transform>().Length == 1)
            {
                level.isWaving = false;
            }
        }
    }
}

