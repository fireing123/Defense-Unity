using static Enemy.EnemyTypes;


public class Level1 : LevelWaves
{
    public string[][] Level;
    public int s = 2;

    

    private void Awake()
    {
       LevelWaves a = new LevelWaves(2, 10);
        a.FillArray(wave1, wave2);
    }
    

    public static string[] wave1 =
    {
        Slime,Slime,Slime,Slime,Slime,Slime,
    };

    public static string[] wave2 =
    {
        Slime,Slime,Slime,Slime,Slime,Slime,
    };

    public Level1(int row, int columns) : base(row, columns)
    {
    }
}