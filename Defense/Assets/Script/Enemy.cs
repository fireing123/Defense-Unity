using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        var LoadManger = GameObject.Find("Load").GetComponent<Load>();
    }

}

