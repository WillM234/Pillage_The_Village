using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBagControl : Collectable
{
    private void Awake()
    {
        LootValue = 500;
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreScript.Score += LootValue;
            Destroy(gameObject);
        }
    }
}
