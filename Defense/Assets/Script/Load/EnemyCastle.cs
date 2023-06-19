

using Enemy;
using UnityEngine;

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
       
        if (!level.isWaving)
        {
           
            if (level.UpdateWave())
            {
                level.isWaving = true;
                waveFather = new(level.waveName);
                level.SpawnWave(waveFather.transform, transform.position, 2f);
            }

        }

        if (waveFather.GetComponentsInChildren<Transform>().Length == 1)
        {
            level.isWaving = false;
        }
    }
}
