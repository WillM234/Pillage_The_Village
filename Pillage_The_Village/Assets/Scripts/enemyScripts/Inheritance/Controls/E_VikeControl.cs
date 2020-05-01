using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_VikeControl : Attack
{
    private int currentHealth;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EnemyName = "Knight";
        EnemyHealth = 2;
        WalkingSpeed = .01f;
        attackRadius = 2f;
        startingPos = this.transform.position;
        currentHealth = EnemyHealth;
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAxe" && other.gameObject.GetComponentInChildren<BoxCollider2D>().isTrigger == true)
        {
            currentHealth -= 1;
            isPLayerAgressive.PlayerIsAgressive = true;
            audioSource.clip = RandomSound.MaleScreams_Sounds[Random.Range(0, RandomSound.MaleScreams_Sounds.Length)];
            audioSource.Play();
        }
        if (other.gameObject.tag == "Player")
        {
            CollidedWithPlayer = true;
            if(CollidedWithPlayer == true && isPLayerAgressive.PlayerIsAgressive == true)
            {
                DoDamage();
            }
        }
    }

    public override void OnTriggerStay2D(Collider2D stay)
    {
        if (stay.gameObject.tag == "Player")
        {
            CollidedWithPlayer = false;
        }
    }
    public override void OnTirggerExit2D(Collider2D exit)
    {
        if (exit.gameObject.tag == "Player")
        {
            CollidedWithPlayer = false;
        }
    }

    public override void DoDamage()
    {
        Player.GetComponent<PlayerMovement>().TakeDamage(1);
    }

    public override void DestroySelf()
    {
        if (currentHealth <= 0)
        {
            AxeKillSlider.value += 1;
            Destroy(gameObject);
        }
    }
}

