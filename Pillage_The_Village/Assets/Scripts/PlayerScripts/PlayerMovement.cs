using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player values")]
    public float runSpeed;
    public float jumpForce;
    public int jumpCount = 0;
    public int PlayerHealth = 2;
    public Slider healthSlider;
    public Slider KillSlider;
    public GameObject PausePanel;
    public PlayerAgressivenessTracker isPlayerAgressive;

    [Header("Bools")]
    public bool isPaused;
    public bool canJump;
    public bool isGrounded;

    [Header("Animation Bools")]
    Animator PlayerAnimator;
    public bool IsWalking;
    public bool Attack;

    [Header("Audio Stuff")]
    public AudioSource audioSource;
    public AudioClip AxeSlash;
    public RandomSoundSelection RandomSound;



    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;
        PlayerAnimator.SetBool("isWalking", IsWalking);
        PlayerAnimator.SetBool("canAttack", Attack);
        if(jumpCount == 0)
        {
            canJump = true;
            isGrounded = true;
        }
        else if(jumpCount > 0)
        {
            canJump = false;
            isGrounded = false;
        }
 ////////Player inputs and movements/////////
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;
        }//Sets game to pause
        if(isPaused == true)
        {
            PausePanel.SetActive(true);
        }
      if(isPaused == false)
        {
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
                transform.localScale = new Vector2(1, transform.localScale.y);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(runSpeed, 0));
                audioSource.clip = RandomSound.Walking_Sounds[Random.Range(0, RandomSound.Walking_Sounds.Length)];
                audioSource.Play();
                IsWalking = true;
            }//moving right
            else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
                transform.localScale = new Vector2(-1, transform.localScale.y);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-runSpeed, 0));
                audioSource.clip = RandomSound.Walking_Sounds[Random.Range(0, RandomSound.Walking_Sounds.Length)];
                audioSource.Play();
                IsWalking = true;
            }//moving leff
            else
			{
                IsWalking = false;
			}
            if (Input.GetKeyDown(KeyCode.I))
            {
                PlayerAnimator.SetTrigger("attack");
                Debug.Log("Attack");
                audioSource.clip = AxeSlash;
                audioSource.Play();
            }
            if(Input.GetKeyDown(KeyCode.O) && KillSlider.value == 10)
                {
                PlayerAnimator.SetTrigger("axeThrow");
                audioSource.clip = RandomSound.Gudrik_sounds[Random.Range(0, RandomSound.Gudrik_sounds.Length)];
                audioSource.Play();
                KillSlider.value = 0;
                }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if(canJump == true && isGrounded == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                    jumpCount += 1;
                }
            }//jumping
           
        }// stuff that is allowed to happen if the game is not paused
        healthSlider.value = PlayerHealth;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
		{
            jumpCount = 0;
		}
    }
    public void unPauseGame()
    {
        isPaused = false;
        PausePanel.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy" && isPlayerAgressive.PlayerIsAgressive == true)
        {
            PlayerHealth -= 1;
        }
    }
}
