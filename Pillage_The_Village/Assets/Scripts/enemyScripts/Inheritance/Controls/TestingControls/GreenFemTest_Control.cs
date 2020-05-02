using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFemTest_Control : PatrolingAttack
{
    private int currentHealth;

    public override void Awake()
    {
        SelectTarget();
        intTimer = Timer;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        WalkingSpeed = 1f;
        attackRadius = .5f;
        EnemyName = "Lass";
        EnemyHealth = 1;
        startingPos = this.transform.position;
        
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && isPLayerAgressive.PlayerIsAgressive == true)
        {
            Target = other.transform.position;
            inRange = true;
            Flip();
        }
    }

    public override void OnTirggerExit2D(Collider2D exit)
    {
        if (exit.gameObject.tag == "Player")
        {
            attackMode = false;
            Target = LeftLimit;
        }

    }
}
