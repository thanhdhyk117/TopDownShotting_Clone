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
   public static int playerData
    {
        set => PlayerPrefs.SetInt(PrefsConsts.PLAYER_DATA_KEY, value);
        get => PlayerPrefs.GetInt(PrefsConsts.PLAYER_DATA_KEY, 0);
    }
   public static int playerWeaponData
    {
        set => PlayerPrefs.SetInt(PrefsConsts.PLAYER_WEAPON_DATA_KEY, value);
        get => PlayerPrefs.GetInt(PrefsConsts.PLAYER_WEAPON_DATA_KEY, 0);
    }
   public static int enemyData
    {
        set => PlayerPrefs.SetInt(PrefsConsts.ENEMY_DATA_KEY, value);
        get => PlayerPrefs.GetInt(PrefsConsts.ENEMY_DATA_KEY, 0);
    }

    public static bool IsEnoughCoins(int coinToCheck)
    {
        return coins >= coinToCheck;
    }
}
