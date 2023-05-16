using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    enum CastleType
    {
        AsmodianEnemy, // START
        HumanEnemy, 
        Ally, // END
    }

    public string castleName;
    public string castleType;
    public int castleMaxHp;
    public int castleNowHp;
    public bool isCastleDistroy = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
