using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemControl : Collectable
{
    private void Awake()
    {
        LootValue = 100;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            scoreScript.Score += LootValue;
            Destroy(gameObject);
        }
    }
}
