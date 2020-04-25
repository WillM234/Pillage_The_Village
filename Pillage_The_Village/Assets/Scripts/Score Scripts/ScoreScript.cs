using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    private void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ("Score: " + Score);
    }
}
