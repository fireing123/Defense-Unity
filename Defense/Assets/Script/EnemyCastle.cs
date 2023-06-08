using Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy.EnemyTypes;

public class EnemyCastle : Castle
{

    public EnemyPrefabManager world;

    // Start is called before the first frame update
    void Start()
    {
        world.SpawnEnemy(Slime, transform.position);
    }
    
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

}
