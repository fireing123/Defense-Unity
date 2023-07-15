using AllyEntity;
using Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUISetting : PrefabManger<AllySelectData>
{
    public GameObject SelectList;
    public GameObject SelectButtonPrefab;
    public CreateTower createTower;
    private void Awake()
    {
        LoadAllyButtonPrefabs();
    }

    private void Start()
    {
        
    }

    public void LoadAllyButtonPrefabs()
    {
        AllySelectData allyData = LoadPrefab();
        foreach (AllySelectInfo item in allyData.allys)
        {
            GameObject _object = InsertButton();
            _object.TryGetComponent(out Image image);
            _object.TryGetComponent(out Button button);
            image.sprite = Loads<Sprite>(item.photo);
            button.onClick.AddListener(delegate()  {
                createTower.SetBuildClick(Loads<GameObject>(item.objectPath)); 
            });
        }
    }

    private T Loads<T>(string path) where T : Object
    {
        if (path == null) throw new System.NullReferenceException(path + " is null");
        T t= Resources.Load<T>(path);
        if (t == null) throw new System.NullReferenceException(path + " this Path is not "+ typeof(T) +" Path");
        return t;
    }

    private GameObject InsertButton()
    {
        GameObject select = Instantiate(SelectButtonPrefab);
        select.transform.SetParent(transform, false);
        return select;
    }
}
