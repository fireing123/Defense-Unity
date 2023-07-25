using Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger
{
    private static GameObject canves;
    private static GameObject HpBarPerant;
    private static GameObject HPbarPrefab;

    public static void SetCanves(GameObject _canves, GameObject prefab)
    {
        canves = _canves;
        HpBarPerant = new("HP_BARS");
        HpBarPerant.transform.parent = canves.transform;
        HPbarPrefab = prefab;
    }



    public static GameObject SpawnBar()
    {
        GameObject obj = Object.Instantiate(HPbarPrefab, HpBarPerant.transform);
        return obj;
    }
}
