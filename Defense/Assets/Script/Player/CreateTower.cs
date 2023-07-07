using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static LayerType.Layers;

public class CreateTower : MonoBehaviour
{

    Camera _Camara = null;

    private bool _mouseState;

    private GameObject target;

    private Vector3 _mousePosition;

    public GameObject buildClick;

    private PlayerControl _playerControl;

    private void Start()
    {
        _playerControl = GetComponent<PlayerControl>();
        _Camara = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) OnMouseButtonDown();

    }

    

    public void SetBuildClick(GameObject @object)
    {
        buildClick = @object;
    }

    private void OnMouseButtonDown()
    {
        GameObject _obj = GetClickObject();
        
        if (_obj?.layer == (int)Layer.Install && BuildAlly(_obj))
        {

        }



    } 

    private bool BuildAlly(GameObject obj)
    {
        if (_playerControl.GetAccount() < AllyPrices.Turret) return false;
        var node = obj.GetComponent<InstallNode>();
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
