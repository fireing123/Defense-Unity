

using Enemy;
using UnityEngine;

public class EnemyCastle : Castle
{

    public EnemyPrefabManager world;

    [SerializeField]
    private GameObject waveFather;

    void Start()
    {
        
    }
    
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Debug.Log(world.waves.UpdateLevel());
        if (world.isWaveEnd)
        {
            waveFather = world.UpdateWave(transform.position, 2.0f, world.GetWaveInt());
        }

        if (waveFather.GetComponentsInChildren<Transform>().Length == 1) world.isWaveEnd = true;
    }


}
