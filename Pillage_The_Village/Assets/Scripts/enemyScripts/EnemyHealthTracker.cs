using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthTracker : MonoBehaviour
{
    public EnemyAsset enemyAsset;
    public RandomSoundSelection RandomSound;
    public int Health;
    public int Speed;
    public Slider KillSlider;
    public AudioClip AxeKill;
    public AudioSource GMPlayer;

    private void Awake()
    {
        Health = enemyAsset.Health;
        Speed = enemyAsset.WalkingSpeed;
       
    }

    // Update is called once per frame
    void Update()
    {

    ///////HEALTH TRACKING///////
        if(Health == 0)
        {
           
            KillSlider.value += 1;//increases KillSlider value by one upon death
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerAxe" && other.gameObject.GetComponentInChildren<BoxCollider2D>().isTrigger == true)
        {
            if(gameObject.tag == "FemNPC")
            {
                GMPlayer.clip = RandomSound.FemaleScreams_Sounds[Random.Range(0, RandomSound.FemaleScreams_Sounds.Length)];
                GMPlayer.Play();
            }
            if(gameObject.tag == "MaleNPC")
            {
                GMPlayer.clip = RandomSound.MaleScreams_Sounds[Random.Range(0, RandomSound.MaleScreams_Sounds.Length)];
                GMPlayer.Play();
            }
            Health -= 1;
        }
    }
}
