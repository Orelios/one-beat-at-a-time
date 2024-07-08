using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OffsetPlayerInput : MonoBehaviour
{
    public OffsetNoteDetection detector;
    public PatternSpawner[] patternSpawner;
    private Arrows arrows;
    public UnityEvent playerPressEvent;
    public UnityEvent playerPressMissEvent;
    public GameObject offsetSettings;
    void Update()
    {
        DetectArrowInput();
    }

    public void DetectArrowInput()
    {
        if (Player.Instance.canPress == true && offsetSettings.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                playerPressEvent.Invoke();
            }

        }
        else if (Player.Instance.canPress == false && offsetSettings.activeSelf) // miss == pressed arrow when not in early/perfect/late timings
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                playerPressMissEvent.Invoke();
            }
        }
    }
}

