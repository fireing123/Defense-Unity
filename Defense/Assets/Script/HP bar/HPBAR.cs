using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
[Serializable]
public class HPBAR
{

    public GameObject Bar;

    public Image image;

    private Camera mainCamera;

    public HPBAR(string name)
    {
        Bar = UIManger.SpawnBar();
        Bar.name = name;
        image = Bar.transform.GetChild(0).GetComponent<Image>();
        mainCamera = Camera.main;
    }

    public void TransformTrans(Vector3 position, float height) 
    {
        
        float distance = Vector3.Distance(mainCamera.transform.position, position);
        if (distance > 100) { Bar.SetActive(false); return; }
        else { Bar.SetActive(true); }
        float normalizedDistance = Mathf.InverseLerp(5, 20, distance);
        
        float newSize = Mathf.Lerp(2, 0.5f, normalizedDistance) * 0.2f;


        Transform transform = Bar.transform;
        transform.position = mainCamera.WorldToScreenPoint(position + new Vector3(0, height, 0));

        // HP 바의 크기 조정
        transform.localScale = new Vector3(newSize, newSize, newSize);
    }

    public void SetHP(float hp)
    {
        image.fillAmount = hp;
    }
}
