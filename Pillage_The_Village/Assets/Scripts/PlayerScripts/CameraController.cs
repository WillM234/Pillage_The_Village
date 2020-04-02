using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
        //calculates and stores offset value. gets position distance between player and camera 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
        //Sets position of the camera as the players, but offset by the calculated offset distance 
    }
}
