using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleNPC_Control : Attack
{
    private int currentHealth;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EnemyName = "Farmer";
        EnemyHealth = 1;
        WalkingSpeed = .02f;
        attackRadius = 1f;
        startingPos = this.transform.position;
        currentHealth = EnemyHealth;
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAxe" && other.gameObject.GetComponentInChildren<BoxCollider2D>().isTrigger == true)
        {
            randomSound();
            audioSource.clip = PlayingSound;
            audioSource.Play();
            isPLayerAgressive.PlayerIsAgressive = true;
            currentHealth -= 1;
        }
        if (other.gameObject.tag == "Player")
        {
            CollidedWithPlayer = true;
            if (CollidedWithPlayer == true && isPLayerAgressive.PlayerIsAgressive == true)
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

    public override void randomSound()
    {
        SoundCount = Random.Range(1, 3);
        if (SoundCount == 1)
        {
            PlayingSound = Sound1;
        }
        if (SoundCount == 2)
        {
            PlayingSound = Sound2;
        }
    }

    public override void AddToSlider(int value)
    {
        AxeKillSlider.value += value;
    }

    public override void DestroySelf()
    {
        if (currentHealth <= 0)
        {
            AddToSlider(1);
            Destroy(gameObject);
        }
    }
}
