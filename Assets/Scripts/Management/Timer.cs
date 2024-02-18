using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    public float seconds = 0.0f;
    public int minutes = 0;
    //public int hours = 0;
    [SerializeField]
    private bool isGameTimerRunning = true;
    [SerializeField]
    private float initialSeconds = 0.0f;
    [SerializeField]
    private int initialMinutes = 0;

    TextMeshProUGUI text;

    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //seconds = 0.0f;
        //minutes = 0;
        //hours = 0;
        seconds = initialSeconds;
        minutes = initialMinutes;
        //text = GetComponent<TextMeshProUGUI>();
        //text.text = "" + minutes.ToString("00") + ":" + seconds.ToString("00"); //seconds.ToString("F1") for 1 decimal
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameTimerRunning == true)
        {
            seconds -= Time.deltaTime;
            if (minutes <= 0)
            {
                if (seconds <= 0)
                {
                    StopGameTimer();
                }
                else if (seconds > 59.0f && seconds <= 60.0f)
                {
                    //text.text = "" + (minutes + 1).ToString("00") + ":" + "00"; //when seconds is 60, display as 0 and minutes+1
                }
                else if (seconds <= 59.0f)
                {
                    //text.text = "" + minutes.ToString("00") + ":" + seconds.ToString("00");
                }
            }
            else if (minutes > 0)
            {
                if (seconds <= 0.0f)
                {
                    seconds += 60.0f;
                    minutes -= 1;
                }
                if (seconds > 59.0f && seconds <= 60.0f)
                {
                    //text.text = "" + (minutes + 1).ToString("00") + ":" + "00"; //when seconds is 60, display as 0 and minutes+1
                }
                else if (seconds <= 59.0f)
                {
                    //text.text = "" + minutes.ToString("00") + ":" + seconds.ToString("00");
                }
            }
        }
    }

    public void StopGameTimer()
    {
        isGameTimerRunning = false;
        EndRhythmScreen.Instance.StopGame();
    }

    public void RestartGameTimer()
    {
        seconds = initialSeconds;
        minutes = initialMinutes;
        isGameTimerRunning = true;
    }
}
