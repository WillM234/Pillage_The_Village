using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LootParent : MonoBehaviour
{
    public int LootValue;
    public ScoreScript scoreScript;
    public GameObject Player;
    private void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreScript>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
