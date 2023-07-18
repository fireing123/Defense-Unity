using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LayerType;

public class CreateTower : MonoBehaviour
{

    Camera _Camara = null;

    public static GameObject buildClick;

    private PlayerControl _playerControl;

    private void Start()
    {
        TryGetComponent(out _playerControl);
        _Camara = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnMouseButtonDown();
    }

    

    public static void SetBuildClick(GameObject @object)
    {
        buildClick = @object;
        EventsManger.SelectEvent.Invoke(@object.name);
    }

    private void OnMouseButtonDown()
    {
        GameObject _obj = GetClickObject();
        
        if (_obj?.layer == (byte)Layer.Install && BuildAlly(_obj))
        {
            _obj.layer = (byte)Layer.Installed;
        }
    } 

    private bool BuildAlly(GameObject obj)
    {
        if (_playerControl.GetAccount() < AllyPrices.Turret) return false;
        obj.TryGetComponent(out InstallNode node);
        node.Install(buildClick);
        _playerControl.SubGold(AllyPrices.Turret);
        return true;
    }


    private GameObject GetClickObject()
    {
        Ray ray = _Camara.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out RaycastHit hit))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

}
