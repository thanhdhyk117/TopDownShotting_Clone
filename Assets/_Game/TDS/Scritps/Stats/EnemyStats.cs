using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "DATA/TopDownS/Create Enemy")]
public class EnemyStats : ActorStats
{
    [Header("Bonus: ")]
    public float minXpBonus;
    public float maxXpBonus;

    [Header("Level up:")]
    public float hpUp;
    public float damageUp;
}
