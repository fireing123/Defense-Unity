using EnemyEntity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALL_MANGER : MonoBehaviour
{
    [Header("JSON Asset")]
    public TextAsset EnemyPrefabs;
    public TextAsset EnemyWaves;
    public TextAsset AllyPrefabs;

    [Header("UI Button")]
    public GameObject ButtonPrefab;
    public GameObject ButtonPerant;

    [Header("UI Manger")]
    public GameObject Canves;
    public GameObject HPBarPrefabs;
    private void Awake()
    {
        EnemyPrefabManager.LoadEnemyPrefabs(EnemyPrefabs);
        EnemyWave.LoadEnemyWaves(EnemyWaves);
        UIManger.SetCanves(Canves, HPBarPrefabs);
    }

    private void OnEnable()
    {
        SelectUISetting.LoadAllyButtonPrefabs
            (
            AllyPrefabs,
            ButtonPerant,
            ButtonPrefab
            );
    }
}
