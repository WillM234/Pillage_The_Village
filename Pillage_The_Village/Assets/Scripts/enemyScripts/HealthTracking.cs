using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracking : MonoBehaviour
{
    #region Public Stuff
    public GameObject ThisObject;
    public Slider KillSlider;
    public AudioClip PlayingSound;
    public AudioClip Sound1;
    public AudioClip Sound2;

    #endregion
    #region Private Stuff
    public int currentHealth;
    private GameObject GMObject;
    private AudioSource AudioS;
    private float SoundCount;
    #endregion

    private void Awake()
    {
        
        AudioS = GetComponentInParent<AudioSource>();
        GMObject = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void Update()
    {
        DestroySelf();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerAxe" && collision.gameObject.GetComponent<BoxCollider2D>().isTrigger == true)
        {
            RandomSound();
            AudioS.PlayOneShot(PlayingSound);
            GMObject.GetComponent<PlayerAgressivenessTracker>().PlayerIsAgressive = true;
            currentHealth -= 1;
        }
    }
   
    private void RandomSound()
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

    private void DestroySelf()
    {
        if(currentHealth <= 0)
        {
            AddToSlidder(1);
            Destroy(ThisObject);
        }
    }

    private void AddToSlidder(int value)
    {
        KillSlider.value = KillSlider.value + value;
    }


}
