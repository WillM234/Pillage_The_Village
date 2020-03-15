using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsset : ScriptableObject
{
    private EnemyAsset enemyAsset;

    [Header("General Info")]
    public int Health;
    public int Armor;

    public EnemyAsset(EnemyAsset enemyAsset)
	{
        this.enemyAsset = enemyAsset;
	}
}
