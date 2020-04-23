using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_VikeControl : Attack
{
    private void Awake()
    {
        EnemyName = "Knight";
        EnemyHealth = 2;
        WalkingSpeed = .01f;
        attackRadius = 2f;
        startingPos = this.transform.position;
    }
}
