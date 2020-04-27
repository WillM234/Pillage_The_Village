using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : Destructable
{
    private void Awake()
    {
        LootValue = 200;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerAxe" && other.GetComponentInChildren<BoxCollider2D>().isTrigger == true)
        {
            scoreScript.Score += LootValue;
            Destroy(gameObject);
        }
    }
}
