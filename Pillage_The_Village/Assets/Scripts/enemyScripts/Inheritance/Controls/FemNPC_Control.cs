using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemNPC_Control : Attack
{

    private void Awake()
    {
        EnemyName = "Lass";
        EnemyHealth = 1;
        WalkingSpeed = .02f;
        attackRadius = .5f;
        startingPos = this.transform.position;
        //LeftMax_MinValue = startingPos.x - .2f;
        //RightMax_MinValue = startingPos.x + .2f;

    }
}
