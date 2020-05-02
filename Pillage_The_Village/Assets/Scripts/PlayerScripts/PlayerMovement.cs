using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player values")]
    public float runSpeed;//Player walking speed
    public float jumpForce;//how hard the player jumps
    public int jumpCount = 0;//how many times the player has jumped while in the air
    public int PlayerHealth;//player's starting health
    public int CurrentHealth;//player's health that is modified
    public Slider healthSlider;//reference for the slider that shows the players health in the UI
    public Slider KillSlider;//reference for the slider that increases when a player kills an enemy
    public GameObject GameOverWin;
    public GameObject GameOverDeath;//reference for the Panel that shows when the player dies by time running out or losing all their health
    public GameObject PausePanel;//reference for the panel that shows when the game is paused
    public PlayerAgressivenessTracker isPlayerAgressive;//reference to the script that holds the bool that tracks if the player becomes agressive

    [Header("Bools")]
    public bool CanBeDamaged;//if true, player can take damage
    public bool isPaused;// flags if the player pauses the game
    public bool canJump;// flags if the player can jump
    public bool isGrounded;// flags if the player is on the ground or in the air

    [Header("Animation Bools")]
    Animator PlayerAnimator;//reference for the player sprite animator 
    public bool IsWalking;//reference for walking animation to be triggered when player is moving 
    public bool Attack;//referece for attacking animation to be triggered when player wants to attack
    public Animation basicAtk;
    public Animation AxeThrow;

    [Header("Audio Stuff")]
    public AudioSource audioSource;//reference for the audio source of the player
    public AudioSource AxeAudioSource;//reference for the audio source of the player's axe
    public AudioClip PlayingClip;
    public AudioClip AxePlayingClip;
    public AudioClip AxeSlash;//refernce for the slashing sound effect of the axe
    public AudioClip MovementSound;//reference for movement sounds for player
    public AudioClip RandomGudrik;//Reference for Gudrik Sounds
    public float GudrikCounter;
    public AudioClip Gudrik1;
    public AudioClip Gudrik2;
    public AudioClip Gudrik3;
    public AudioClip Gudrik4;
    public RandomSoundSelection RandomSound;//reference to the script that holds the audioclips in an array



    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();//sets player's animator
        audioSource = GetComponent<AudioSource>();//Sets player's Audio Source
        AxeAudioSource = GetComponentInChildren<AudioSource>();//Set's axe's audio source
        CurrentHealth = PlayerHealth;//Sets player's current health to the starting health
        healthSlider.value = CurrentHealth;//sets sliders value to Player's starting health value
         
      
    }

    // Update is called once per frame
    void Update()
    {
        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;//tracks velocity in the y-axis 
        PlayerAnimator.SetBool("isWalking", IsWalking);//sets bool for walking animation
        PlayerAnimator.SetBool("canAttack", Attack);//sets bool for attacking animation(axe throw)
        if(jumpCount == 0)//what heppens when jump count is at zero 
        {
            canJump = true;//allows player to jump
            isGrounded = true;//player becomes grounded
        }
        else if(jumpCount > 0)
        {
            canJump = false;//player cannot jump
            isGrounded = false;
        }
 ////////Player inputs and movements/////////
        if (Input.GetKeyDown(KeyCode.P))//when the P-key is pressed
        {
            isPaused = true;
        }//Sets game to pause
        if(isPaused == true)
        {
            PausePanel.SetActive(true);
        }//Sets the pause pannel to active in heirarchy
      if(isPaused == false)
        {
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//when the D key or Right arrow key is pressed
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);//sets the players velocity
                transform.localScale = new Vector2(1, transform.localScale.y);//changes which way the player is facing based on the local scale
                GetComponent<Rigidbody2D>().AddForce(new Vector2(runSpeed, 0));//adds for to the player so they can move, only on the x-axis
                PlayingClip = MovementSound;//grabs sound when moving 
                PlaySoundPlayer();
                IsWalking = true;//transitions animation to walking
            }//moving right
            else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                
                GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);//sets the players velocity
                transform.localScale = new Vector2(-1, transform.localScale.y);//changes which way the player is facing based on the local scale
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-runSpeed, 0));//adds for to the player so they can move, only on the x-axis
                PlayingClip = MovementSound;
                PlaySoundPlayer();
                IsWalking = true;//transitions animation to walking
            }//moving leff
            else
			{
                CanBeDamaged = true;
                IsWalking = false;//player is not walking if the they keys for walking are not pressed
			}
            if (Input.GetKeyDown(KeyCode.I))//basic attack 
            {
                CanBeDamaged = false;
                PlayerAnimator.SetTrigger("attack");//triggers basic attack animation
                AxePlayingClip = AxeSlash;//plays Slashing clip
                PlaySoundAxe();
            }
            if(Input.GetKeyDown(KeyCode.O) && KillSlider.value == 4)//throwing axe attack, if slider value is high enough
                {
                CanBeDamaged = false;
                randomGudrik();//chooses random sound from the ones given when the key is pressed
                PlayerAnimator.SetTrigger("axeThrow");//triggers throwin axe animation
                AxePlayingClip = RandomGudrik;
                PlaySoundAxe();
                KillSlider.value = 0;//resets slider value
                }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if(canJump == true && isGrounded == true)//as long as the player is grounded and is able to jump
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));//adds force to make player jump
                    jumpCount += 1;//adds one to jump count, more usefull for multipjumps
                }
            }//jumping
           
        }// stuff that is allowed to happen if the game is not paused
        healthSlider.value = CurrentHealth;//sets health slider equal to player's health constantly
        if(CurrentHealth  <= 0)
        {
            GameOverDeath.SetActive(true);
        }//what happens when player's health is 0
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")//if the object the player is colliding with is the ground
		{
            jumpCount = 0;//resets the jump count
		}
        if(other.gameObject.tag == "end")
        {
            GameOverWin.SetActive(true);
        }
    }
    public void unPauseGame()
    {
        isPaused = false;//unpauses the player and enemies
        PausePanel.SetActive(false);
    }//function used to resume the game through the UI
  
    public void TakeDamage(int Damage)
    {
        if(CanBeDamaged)//if true
        {
            CurrentHealth -= Damage;//Player takes damage
        }
        
    }

    public void randomGudrik()//function to set random gudrik sound, called when key is pressed for Axe throw
    {
       GudrikCounter =  Random.Range(1, 5);//chooses a number between and including 1-4(note: 5 is not available to be choosen)
        if(GudrikCounter == 1)//when 1 is choosen
        {
            RandomGudrik = Gudrik1;//random sound becomes sound #1, is set in inspector
        }
        if (GudrikCounter == 2)//when 2 is choosen
        {
            RandomGudrik = Gudrik2;//random sound becomes sound #2, is set in inspector
        }
        if (GudrikCounter == 3)//when 3 is choosen
        {
            RandomGudrik = Gudrik3;//random sound becomes sound #3, is set in inspector
        }
        if (GudrikCounter == 4)//when 4 is choosen
        {
            RandomGudrik = Gudrik4;//random sound becomes sound #4, is set in inspector
        }
    }

    private void PlaySoundPlayer()
	{
        audioSource.PlayOneShot(PlayingClip);
	}
    private void PlaySoundAxe()
	{
        AxeAudioSource.PlayOneShot(AxePlayingClip);
	}
}
