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
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SoundEffectManager.Instance.PlayInputSound();
                SendPlayerArrowInput(Arrows.Up, 0, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Up);
                Player.Instance.canPress = false;
                detector.DestroyNote();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SoundEffectManager.Instance.PlayInputSound();
                SendPlayerArrowInput(Arrows.Down, 1, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Down);
                Player.Instance.canPress = false;
                detector.DestroyNote();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SoundEffectManager.Instance.PlayInputSound();
                SendPlayerArrowInput(Arrows.Left, 2, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Left);
                Player.Instance.canPress = false;
                detector.DestroyNote();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SoundEffectManager.Instance.PlayInputSound();
                SendPlayerArrowInput(Arrows.Right, 3, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Right);
                Player.Instance.canPress = false;
                detector.DestroyNote();
            }
        }
        else if (Player.Instance.canPress == false) // miss == pressed arrow when not in early/perfect/late timings
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SoundEffectManager.Instance.PlayMissSound();
                Player.Instance.canPress = false;
                SendPlayerArrowInput(Arrows.Up, 0, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Up);
                IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SoundEffectManager.Instance.PlayMissSound();
                Player.Instance.canPress = false;
                SendPlayerArrowInput(Arrows.Down, 1, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Down);
                IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SoundEffectManager.Instance.PlayMissSound();
                Player.Instance.canPress = false;
                SendPlayerArrowInput(Arrows.Left, 2, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Left);
                IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SoundEffectManager.Instance.PlayMissSound();
                Player.Instance.canPress = false;
                SendPlayerArrowInput(Arrows.Right, 3, Player.Instance.canPress);
                //IndicatorColor.Instance.ChangeIndicatorColor();
                //IndicatorImage.Instance.ChangeIndicatorImage(Arrows.Right);
                IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
            }
        }
    }
    public void SendPlayerArrowInput(Arrows arrow, int x, bool canPress)
    {
        /*arrows = arrow;
        for (int i = 0; i < patternSpawner.Length; i++)
        {
            patternSpawner[i].PlayerArrowInputs(arrows);
        }*/
        PatternManager.Instance.GetComponent<PatternManager>().ReceivePlayerArrowInput(arrow, x, canPress);
    }
}
