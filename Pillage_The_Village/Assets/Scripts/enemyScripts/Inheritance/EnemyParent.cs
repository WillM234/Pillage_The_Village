using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyParent : MonoBehaviour
{
    public AudioSource audioSource;
    public RandomSoundSelection RandomSound;
    public PlayerAgressivenessTracker isPLayerAgressive;
    public Slider AxeKillSlider;
    public string EnemyName;
    public int EnemyHealth;
    public Vector2 startingPos;
    public float WalkingSpeed;
    public float attackRadius;
    public bool CollidedWithPlayer;
    public bool isMoving;
    public bool canAttack;
    public Animator animator;

   

    // Update is called once per frame
    void Update()
    {
        attack();
        Patrol();
        DestroySelf();
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
    public virtual void DestroySelf()
    {

    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {

    }
    public virtual void OnTriggerStay2D(Collider2D stay)
    {

    }
    public virtual void OnTirggerExit2D(Collider2D exit)
    {

    }
    public virtual void DoDamage()
    {

    }
}
