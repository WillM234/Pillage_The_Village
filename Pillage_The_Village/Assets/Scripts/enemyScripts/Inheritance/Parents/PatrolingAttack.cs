using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PatrolingAttack : EnemyParent
{
    #region Public Stuff
    public Vector2 LeftLimit;
    public Vector2 RightLimit;
    public float Timer;
    public Vector2 Target;
    public Transform RayCast;
    public LayerMask RaycastMask;
    public float RaycastLength;
    public GameObject Player;
    public string AttackAnimationName;
    #endregion

    #region Private Stuff
    private RaycastHit2D Hit;
    public float Distance;
    public float intTimer;
    public bool attackMode;
    public bool inRange;
    private bool cooling;
    #endregion

    public virtual void Awake()
    {
    
    }

    public override void Patrol()
    {
        animator.SetBool("canWalk", isMoving);
        animator.SetBool("Attack", canAttack);

        if(Player.GetComponent<PlayerMovement>().isPaused == false)
        {
            if(isPLayerAgressive.PlayerIsAgressive == false && Player != null)
            {
                Move();
                if(!InsideOfLimits())
                {
                    SelectTarget();
                }
                
               
            }
            if(isPLayerAgressive.PlayerIsAgressive == true && Player != null)
            {
                if (!attackMode)
                {
                    Move();
                  

                }

                if (inRange)
                {
                    Hit = Physics2D.Raycast(RayCast.position, transform.right, RaycastLength, RaycastMask);
                    RaycastDebugger();
                }

                if (inRange == false)
                {
                    StopAttack();
                }

                if (!InsideOfLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimationName))
                {
                    SelectTarget();
                }

                //if the player is detected
                if (Hit.collider != null)
                {
                    EnemyLogic();
                }

                else if (Hit.collider == null)
                {
                    inRange = false;
                }
            }
        }
    }

    private void RaycastDebugger()
    {
        if(Distance > attackRadius)
        {
            Debug.DrawRay(RayCast.position, transform.right * RaycastLength, Color.red);
        }
        else if(attackRadius > Distance)
        {
            Debug.DrawRay(RayCast.position, transform.right * RaycastLength, Color.green);
        }
    }

    private void EnemyLogic()
    {
        Distance = Vector2.Distance(transform.position, Target);
        if(Distance > attackRadius)
        {
            StopAttack();
        }

        else if(attackRadius >= Distance && cooling == false)
        {
            Attack();
        }

        if(cooling == true)
        {
            CoolDown();
            canAttack = false;
        }
    }

    private void Move()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(AttackAnimationName))
        {
            isMoving = true;
            Vector2 targetPosition = new Vector2(Target.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, WalkingSpeed * Time.deltaTime);
        }
    }

    public void SelectTarget()
    {
        float DistanceToLeft = Vector2.Distance(transform.position, LeftLimit);
        float DistanceToRight = Vector2.Distance(transform.position, RightLimit);

        if(DistanceToLeft > DistanceToRight)
        {
            Target = LeftLimit;
        }
        else
        {
            Target = RightLimit;
        }
        Flip();
    }

    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        canAttack = false;
    }

    private void Attack()
    {
        Timer = intTimer;
        attackMode = true;
        isMoving = false;
        canAttack = true;
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private void CoolDown()
    {
        Timer -= Time.deltaTime;

        if(Timer <= 0 && cooling == true && attackMode == true)
        {
            cooling = false;
            Timer = intTimer;
        }
    }

    public void Flip()
    {
        Vector3 Rotation = transform.eulerAngles;
        if(transform.position.x > Target.x)
        {
            Rotation.y = 180f;
        }
        else
        {
            Rotation.y = 0f;
        }
        transform.eulerAngles = Rotation;
    }

    public bool InsideOfLimits()
    {
        return transform.position.x > LeftLimit.x && transform.position.x < RightLimit.x;
    }
}
