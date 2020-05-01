using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : EnemyParent
{
    public PlayerAgressivenessTracker PlayerTracker;
    public GameObject Player;

    public float X_LeftMax;
    public float X_RightMax;
    private float LeftMax_MinValue;
    public float LeftMax_MaxValue;
    private float RightMax_MinValue;
    public float RightMax_MaxValue;
    public Vector3 OffsetFromPlayer;
    private Vector3 offsetDistance;

    private float speed;
    private Vector2 Mvect;

    private void Start()
    {
        offsetDistance = new Vector3(0.5f, 0f, 0f);
        speed = -WalkingSpeed;
        Mvect.x = -1f;
        LeftMax_MinValue = startingPos.x - .2f;
        RightMax_MinValue = startingPos.x + .2f;
        LeftMax(1);
        RightMax(1);
        

    }
    public override void attack()
    {
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("Attacking", canAttack);
        OffsetFromPlayer = Player.transform.position - offsetDistance;

        if (Player.GetComponent<PlayerMovement>().isPaused == false)
        {
            if (PlayerTracker.PlayerIsAgressive == true && Player != null)
            {
                
                isMoving = true;
                if((Player.transform.position - this.transform.position).sqrMagnitude < attackRadius)
                {
                    transform.position = Vector2.Lerp(transform.position, OffsetFromPlayer, WalkingSpeed);
                    transform.localscale
                    canAttack = true;
                }
                else
                {
                    canAttack = false;
                    Vector2 newPos = new Vector2(transform.position.x + Mvect.x * speed, transform.position.y + Mvect.y * speed);
                    if (newPos.x <= X_LeftMax)
                    {
                        speed = -speed;
                        transform.localScale = new Vector2(1, transform.localScale.y);

                    }
                    if (newPos.x >= X_RightMax)
                    {
                        speed = -speed;
                        transform.localScale = new Vector2(-1, transform.localScale.y);

                    }
                    transform.position = newPos;
                }
            }
           
        }
    }

    public override void Patrol()
    {
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("Attacking", canAttack);

        if (Player.GetComponent<PlayerMovement>().isPaused == false)
        {
            if (PlayerTracker.PlayerIsAgressive == false && Player != null)
            {
                isMoving = true;
                Vector2 newPos = new Vector2(transform.position.x + Mvect.x * speed, transform.position.y + Mvect.y * speed);
                if(newPos.x <= X_LeftMax)
                {
                    speed = -speed;
                    transform.localScale = new Vector2(1, transform.localScale.y);
                    
                }
                if(newPos.x >= X_RightMax)
                { 
                    speed = -speed;
                    transform.localScale = new Vector2(-1, transform.localScale.y);
                     
                }
                transform.position = newPos;
            }
        }
        
    }
    public override void LeftMax(int number)
    {
        X_LeftMax = Random.Range(LeftMax_MinValue, LeftMax_MaxValue);
    }
    public override void RightMax(int number)
    {
        X_RightMax = Random.Range(RightMax_MinValue, RightMax_MaxValue);
    }
}
