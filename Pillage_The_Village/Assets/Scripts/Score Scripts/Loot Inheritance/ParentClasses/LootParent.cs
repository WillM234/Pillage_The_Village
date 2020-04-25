using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootParent : MonoBehaviour
{
    public int LootValue;
    public ScoreScript scoreScript;
    public GameObject Player;
    public Animator chestAnimator;
}
