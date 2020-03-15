using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyIntegration 
{
    [MenuItem("Assets/Create/EnemyAsset")]

    public static void CreateEnemyScriptableObject()
	{
        SOUtility.CreateAsset<EnemyAsset>();
	}
}
