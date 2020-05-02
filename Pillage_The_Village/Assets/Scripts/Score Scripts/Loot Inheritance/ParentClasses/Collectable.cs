using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : LootParent
{
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
