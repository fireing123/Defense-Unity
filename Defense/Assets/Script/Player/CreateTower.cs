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

    private void Start()
    {
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
        Debug.Log("hello");
        GameObject _obj = GetClickObject();
        Debug.Log(_obj?.name);
        if (_obj?.layer == (int)Layer.Install)
        {
            var node = _obj.GetComponent<InstallNode>();
            node.Install(buildClick);
        }

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
