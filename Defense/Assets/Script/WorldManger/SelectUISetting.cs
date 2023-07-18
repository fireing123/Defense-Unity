using AllyEntity;
using Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SelectUISetting : PrefabManger<AllySelectData>
{
    public static GameObject SelectList;
    public static GameObject SelectButtonPrefab;


    public static void LoadAllyButtonPrefabs(TextAsset JsonText ,GameObject _SelectList, GameObject _SelectButtonPrefab)
    {
        SelectList = _SelectList;
        SelectButtonPrefab = _SelectButtonPrefab;
        AllySelectData allyData = LoadPrefab(JsonText.text);
        foreach (AllySelectInfo item in allyData.allys)
        {
            GameObject _object = InsertButton();
            Debug.Log(_object.name);
            _object.transform.GetChild(0).TryGetComponent(out UnityEngine.UI.Image image);
            _object.TryGetComponent(out UnityEngine.UI.Button button);
            image.sprite = Loads<Sprite>(item.photo);
            button.onClick.AddListener(delegate()  {
                CreateTower.SetBuildClick(Loads<GameObject>(item.objectPath)); 
            });
        }
    }

    private static T Loads<T>(string path) where T : Object
    {
        if (path == null) throw new System.NullReferenceException(path + " is null");
        T t= Resources.Load<T>(path) ?? throw new System.NullReferenceException(path + " this Path is not "+ typeof(T) +" Path");
        return t;
    }

    private static GameObject InsertButton()
    {
        GameObject select = Instantiate(SelectButtonPrefab, SelectList.transform);
        return select;
    }
}
