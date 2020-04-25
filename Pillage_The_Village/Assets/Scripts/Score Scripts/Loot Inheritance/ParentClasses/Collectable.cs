using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : LootParent
{
    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
