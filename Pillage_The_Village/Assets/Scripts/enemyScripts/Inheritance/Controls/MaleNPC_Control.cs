using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleNPC_Control : Attack
{
    private int currentHealth;

    private void Awake()
    {
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
            currentHealth -= 1;
            isPLayerAgressive.PlayerIsAgressive = true;
            audioSource.clip = RandomSound.MaleScreams_Sounds[Random.Range(0, RandomSound.MaleScreams_Sounds.Length)];
            audioSource.Play();
        }
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
