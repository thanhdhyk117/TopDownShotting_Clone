using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : ScriptableObject //tao 1 khuan mau xu li ve du lieu trong game
{
    public abstract void Save();
    public abstract void Load();
    public abstract void Update(Action OnSucces = null, Action OnFailed = null);
    public abstract bool IsMaxLevel();
}
