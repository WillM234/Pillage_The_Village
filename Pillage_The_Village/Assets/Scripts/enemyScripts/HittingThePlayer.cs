using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingThePlayer : MonoBehaviour
{
    #region Private Stuff
    private GameObject GameM;
    private GameObject Player;
    #endregion
    private void Awake()
    {
        GameM = GameObject.FindGameObjectWithTag("GameManager");
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && GameM.GetComponent<PlayerAgressivenessTracker>().PlayerIsAgressive == true)
        {
            DoDamage();
        }
    }

    private void DoDamage()
    {
        Player.GetComponent<PlayerMovement>().TakeDamage(1);
    }
}
