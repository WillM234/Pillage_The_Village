using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : Openable
{
    public bool isOpen;
    private void Awake()
    {
        LootValue = 1000;
        isOpen = false;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAxe" && Player.GetComponentInChildren<BoxCollider2D>().isTrigger == true)
        {
            chestAnimator.SetBool("ChestIsOpen", isOpen);
            scoreScript.Score += LootValue;
            isOpen = true; 
        }
    }
}
