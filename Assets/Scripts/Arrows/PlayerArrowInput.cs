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
                    SendPlayerArrowInput(Arrows.Up, 0);
                    IndicatorAboveImage.Instance.ChangeAboveIndicatorImage(); 
                    IndicatorColor.Instance.ChangeIndicatorColor();
                    IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Up);
                    detector.DestroyNote();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Down, 1);
                    IndicatorAboveImage.Instance.ChangeAboveIndicatorImage();
                    IndicatorColor.Instance.ChangeIndicatorColor();
                    IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Down);
                    detector.DestroyNote();
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Left, 2);
                    IndicatorAboveImage.Instance.ChangeAboveIndicatorImage();
                    IndicatorColor.Instance.ChangeIndicatorColor();
                    IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Left);
                    detector.DestroyNote();
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Player.Instance.canPress = false;
                    SendPlayerArrowInput(Arrows.Right, 3);
                    IndicatorAboveImage.Instance.ChangeAboveIndicatorImage();
                    IndicatorColor.Instance.ChangeIndicatorColor();
                    IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Right);
                    detector.DestroyNote();
                }
                //The key pressed was not an arrow key
                else
                {
                    //fuction to indicate wrong key pressed
                    IndicatorImage.Instance.ChangeIndicatorImage(Arrows.None);
                }
            }
        }
        else if (Player.Instance.canPress == false) // miss == pressed arrow when not in early/perfect/late timings
        {
            if (Input.anyKeyDown)
            {
                SendPlayerArrowInput(Arrows.Miss, 4); //int 4 wll be used as _incorrectArrowSprites[4]
                IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
            }
        }
    }
    public void SendPlayerArrowInput(Arrows arrow, int x)
    {
        /*arrows = arrow;
        for (int i = 0; i < patternSpawner.Length; i++)
        {
            patternSpawner[i].PlayerArrowInputs(arrows);
        }*/
        PatternManager.Instance.GetComponent<PatternManager>().ReceivePlayerArrowInput(arrow, x);
    }
}
