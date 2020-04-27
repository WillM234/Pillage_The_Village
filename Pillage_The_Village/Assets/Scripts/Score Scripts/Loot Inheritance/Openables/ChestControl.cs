using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : Openable
{
    public bool isOpen;
    public bool collected;
    public Animator chestAnimator;
    private void Awake()
        
    {
        LootValue = 1000;
        isOpen = false;
        collected = false;
    }
    public void Update()
    {
        chestAnimator.SetBool("ChestIsOpen", isOpen);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAxe" && other.GetComponentInChildren<BoxCollider2D>().isTrigger == true && collected == false)
        {
            scoreScript.Score += LootValue;
            isOpen = true;
            collected = true;
        }
    }
}
