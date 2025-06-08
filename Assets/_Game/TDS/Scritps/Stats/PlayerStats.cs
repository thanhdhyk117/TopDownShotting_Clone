using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", menuName = "DATA/TopDownS/Create player")]
public class PlayerStats : ActorStats
{
    [Header("LevelUp base: ")]
    public int level;
    public int maxLevel;
    public float xp;
    public float levelUpXpRequired;

    [Header("Level Up:")]
    public float levelUpXpRequiredUp;
    public float hpUp;

    public override bool IsMaxLevel()
    {
        return level > maxLevel;
    }

    public override void Load()
    {
        base.Load();
        if(!string.IsNullOrEmpty(Prefs.playerData))
        {
            JsonUtility.FromJsonOverwrite(Prefs.playerData, this);
        }
    }

    public override void Save()
    {
        base.Save();
        Prefs.playerData = JsonUtility.ToJson(this);
    }

    public override void Update(Action OnSucces = null, Action OnFailed = null)
    {
        float offset = Helper.GetUpdateFormula(level);
        while (xp >= levelUpXpRequired && !IsMaxLevel())
        {
            level++;
            xp -= levelUpXpRequired;
            
            hp += hpUp * offset;
            levelUpXpRequired += offset;

            Save();

            OnSucces?.Invoke();
        }

        if (xp <= levelUpXpRequired || IsMaxLevel())
        {
            OnFailed?.Invoke();
        }
    }
}
