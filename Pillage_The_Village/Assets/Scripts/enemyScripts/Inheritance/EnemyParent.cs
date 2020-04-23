using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyParent : MonoBehaviour
{
    
    public string EnemyName;
    public int EnemyHealth;
    public Vector2 startingPos;
    public float WalkingSpeed;
    public float attackRadius;
    public bool isMoving;
    public bool canAttack;
    public Animator animator;

   

    // Update is called once per frame
    void Update()
    {
        attack();
        Patrol();
    }

    public virtual void attack()
	{
   
	}

    public virtual void Patrol()
	{
       
	}
    public virtual void LeftMax(int number)
    {

    }
    public virtual void RightMax(int number)
    {

    }
}
