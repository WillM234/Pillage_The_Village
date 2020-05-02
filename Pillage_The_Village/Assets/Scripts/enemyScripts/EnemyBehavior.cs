using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;//minium distance for attack
    public float moveSpeed;
    public float timer;//timer for cooldown between attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;//Store the distance b/w enemy and player
    private bool attackMode;
    private bool inRange;//check if Player is in range
    private bool cooling;//check if enemy is cooling after attack
    private float intTimer;
    #endregion


    private void Awake()
    {
        intTimer = timer;//store inital value of timer
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, raycastLength, raycastMask);
            RayCastDebugger();
        }

        //when Player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;

        }
    }

    void RayCastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * raycastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * raycastLength, Color.green);
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            CoolDown();a
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("GreenFemAtk"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;//reset timer when Player enters attack range
        attackMode = true;// to check if enemy can still attack or not

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);

    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    void CoolDown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
}
