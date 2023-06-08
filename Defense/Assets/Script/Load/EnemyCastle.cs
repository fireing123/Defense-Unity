

using Enemy;

public class EnemyCastle : Castle
{

    public EnemyPrefabManager world;


    void Start()
    {
        world.SpawnEnemy(EnemyTypes.Slime, transform.position);
    }
    
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

}
