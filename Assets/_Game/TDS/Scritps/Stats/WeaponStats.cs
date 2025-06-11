using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Stats", menuName = "DATA/TopDownS/Create weapon")]
public class WeaponStats : Stats
{
    [Header("Base stats: ")]
    public int bullets;
    public float firerate;
    public float reloadTime;
    public float damage;

    [Header("Upgrade: ")]
    public int level;
    public int maxLevel;
    public int bulletsUp;
    public float firerateUp;
    public float reloadTimeUp;
    public float damageUp;
    public int upgradePrice;
    public int upgradePriceUp;

    [Header("Limit: ")]

    public float minFirerate = 0.1f;
    public float minReloadTime = 0.01f;

    public int BulletUpInfo { get => bulletsUp * (level + 1); }

    public float FirerateUpInfo { get => firerateUp * Helper.GetUpdateFormula(level + 1); }
    public float DamageUpInfo { get => damageUp * Helper.GetUpdateFormula(level + 1); }
    public float ReloadTimeUpInfo { get => reloadTimeUp * Helper.GetUpdateFormula(level + 1); }

    public override bool IsMaxLevel()
    {
        return level > maxLevel;
    }

    public override void Load()
    {
        if (!string.IsNullOrEmpty(Prefs.playerWeaponData))
        {
            JsonUtility.FromJsonOverwrite(Prefs.playerWeaponData, this);
        }
    }

    public override void Save()
    {
        Prefs.playerWeaponData = JsonUtility.ToJson(this);
    }

    public override void Update(Action OnSucces = null, Action OnFailed = null)
    {
        if (Prefs.IsEnoughCoins(upgradePrice) && !IsMaxLevel())
        {
            Prefs.coins -= upgradePrice;

            level++;
            bullets += bulletsUp * level;

            firerateUp += firerateUp * Helper.GetUpdateFormula(level);
            firerate = Math.Clamp(firerate, minFirerate, firerate);

            reloadTime -= reloadTimeUp * Helper.GetUpdateFormula(level);
            reloadTime = Mathf.Clamp(reloadTime, minReloadTime, reloadTime);

            damage += damageUp * Helper.GetUpdateFormula(level);
            upgradePrice = upgradePriceUp * level;

            Save();

            OnSucces?.Invoke();
            return;
        }

        OnFailed?.Invoke();
    }
}
