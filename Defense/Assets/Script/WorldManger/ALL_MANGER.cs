using EnemyEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALL_MANGER : MonoBehaviour
{
    public TextAsset EnemyPrefabs;
    public TextAsset EnemyWaves;
    public TextAsset AllyPrefabs;

    public GameObject ButtonPrefab;
    public GameObject ButtonPerant;
    private void Awake()
    {
        
        EnemyPrefabManager.LoadEnemyPrefabs(EnemyPrefabs);
        EnemyWave.LoadEnemyWaves(EnemyWaves);

    }

    private void Start()
    {
        SelectUISetting.LoadAllyButtonPrefabs
            (
            AllyPrefabs, 
            ButtonPerant, 
            ButtonPrefab
            );
    }
}
