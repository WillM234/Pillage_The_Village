using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleNPC_Control : Attack
{

    private void Awake()
    {
        EnemyName = "Farmer";
        EnemyHealth = 1;
        WalkingSpeed = .02f;
        attackRadius = 1f;
        startingPos = this.transform.position;
    }
}
