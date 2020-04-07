using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimerScript : MonoBehaviour
{ 
public int timeLeft = 240;
public Text countDown;
public Text GameOver;
public GameObject MPannel;
// Start is called before the first frame update
void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        MPannel = GameObject.Find("Main_Menu_Pannel");
        MPannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        countDown.text = ("" + timeLeft);
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            GameOver.text = ("Game Over");
            MPannel.SetActive(true);
        }
    }
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
