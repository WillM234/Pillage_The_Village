using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player values")]
    public float runSpeed;
    public float jumpForce;
    public int jumpCount = 0;
    [Header("Bools")]
    public bool isPaused;
    public bool canJump;
    public bool isGrounded;
    [Header("Animation Bools")]
    public bool isWalking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;
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
      if(isPaused == false)
        {
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
                transform.localScale = new Vector2(1, transform.localScale.y);
                isWalking = true;
            }//moving right
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
                transform.localScale = new Vector2(-1, transform.localScale.y);
                isWalking = true;
            }//moving left
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                if(canJump == true && isGrounded == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                }
            }//jumping
        }// stuff that is allowed to happen if the game is not paused
      else
		{
            isWalking = false;
		}
    }
    public void unPauseGame()
    {
        isPaused = false;
    }
}
