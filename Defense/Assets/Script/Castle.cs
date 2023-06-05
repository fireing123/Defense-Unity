using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Load
{

    public string castleName;
    public string castleType;
    public int castleMaxHp;
    public int castleNowHp;
    public bool isCastleDistroy = false;

    public override void Awake()
    {
        base.Awake();
    }

    
    public override void Update()
    {
        base.Update();
    }

    public void HPDrmove(int hp)
    {
        castleNowHp -= hp;
    }
}
