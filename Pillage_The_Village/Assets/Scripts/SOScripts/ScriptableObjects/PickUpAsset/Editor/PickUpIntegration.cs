using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickUpIntegration 
{
   [MenuItem("Assets/Create/PickUpAsset")]

   public static void CreatePickUpScriptableObject()
	{
        SOUtility.CreateAsset<PickUpAsset>();
	}
}
