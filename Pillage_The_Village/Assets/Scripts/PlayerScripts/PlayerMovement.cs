using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Bools")]
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 ////////Player inputs and movements/////////
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;
        }//Sets game to pause
        
    }
}
