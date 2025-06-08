using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs 
{
   public static int coins
    {
        set => PlayerPrefs.SetInt(PrefsConsts.COIN_KEY, value);
        get => PlayerPrefs.GetInt(PrefsConsts.COIN_KEY, 0);
    }
   public static string playerData
    {
        set => PlayerPrefs.SetString(PrefsConsts.PLAYER_DATA_KEY, value);
        get => PlayerPrefs.GetString(PrefsConsts.PLAYER_DATA_KEY);
    }
   public static string playerWeaponData
    {
        set => PlayerPrefs.SetString(PrefsConsts.PLAYER_WEAPON_DATA_KEY, value);
        get => PlayerPrefs.GetString(PrefsConsts.PLAYER_WEAPON_DATA_KEY);
    }
   public static string enemyData
    {
        set => PlayerPrefs.SetString(PrefsConsts.ENEMY_DATA_KEY, value);
        get => PlayerPrefs.GetString(PrefsConsts.ENEMY_DATA_KEY);
    }

    public static bool IsEnoughCoins(int coinToCheck)
    {
        return coins >= coinToCheck;
    }
}
