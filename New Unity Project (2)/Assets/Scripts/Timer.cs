using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    public bool timesUpEvent;

    // Start is called before the first frame update
    void Start()
    {
        timesUpEvent = false;
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        } else
        {
            timesUpEvent = true;
            Time.timeScale = 0;
        }

        if (timesUpEvent == true)
        {
            SceneManager.LoadScene("TimerDone");
        }
       
    }
}
