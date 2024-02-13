using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowInput : MonoBehaviour
{
    public NoteDetection detector;
    public PatternSpawner[] patternSpawner;
    private Arrows arrows;
    void Update()
    {
        DetectArrowInput();
    }

    public void DetectArrowInput()
    {
        if (Player.Instance.canPress == true)
        {
            if (Input.anyKeyDown) //a key was pressed
            {
                //Check if the key pressed was an arrow key
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Up);
                    detector.DestroyNote();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Down);
                    detector.DestroyNote();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Left);
                    detector.DestroyNote();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Right);
                    detector.DestroyNote();
                }
                //The key pressed was not an arrow key
                else
                {
                    //fuction to indicate wrong key pressed
                }
            }
        }
    }
    public void SendPlayerArrowInput(Arrows arrow)
    {
        arrows = arrow;
        for (int i = 0; i < patternSpawner.Length; i++)
        {
            patternSpawner[i].PlayerArrowInputs(arrows, 1);
        }
    }
}
