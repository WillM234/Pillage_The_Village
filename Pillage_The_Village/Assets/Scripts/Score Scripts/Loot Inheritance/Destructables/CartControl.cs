using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartControl : Destructable
{
    private void Awake()
    {
        LootValue = 600;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAxe" && other.gameObject.GetComponentInChildren<BoxCollider2D>().isTrigger == true)
        {
            scoreScript.Score += LootValue;
            Destroy(gameObject);
        }
    }

}
