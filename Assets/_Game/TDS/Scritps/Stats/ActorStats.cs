using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : Stats
{
    [Header("Base Stas: ")]
    public float hp;
    public float damage;
    public float moveSpeed;
    public float knockbackForce;
    public float knockbackTime;
    public float invicibleTime;

    public override bool IsMaxLevel()
    {
        return false;
    }

    public override void Load()
    {
        
    }

    public override void Save()
    {
        
    }

    public override void Update(Action OnSucces = null, Action OnFailed = null)
    {
        
    }
}
