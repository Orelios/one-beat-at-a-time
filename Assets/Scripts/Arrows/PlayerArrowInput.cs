using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PlayerArrowInput : MonoBehaviour
{
    public NoteDetection detector;
    public PatternSpawner[] patternSpawner;
    private Arrows arrows;
    public UnityEvent playerPressEvent;
    public UnityEvent playerPressMissEvent; 
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
                SendPlayerArrowInput(Arrows.Up, 0, Player.Instance.canPress);
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SendPlayerArrowInput(Arrows.Down, 1, Player.Instance.canPress);
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SendPlayerArrowInput(Arrows.Left, 2, Player.Instance.canPress);
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SendPlayerArrowInput(Arrows.Right, 3, Player.Instance.canPress);
                playerPressEvent.Invoke();
            }
        }
        else if (Player.Instance.canPress == false) // miss == pressed arrow when not in early/perfect/late timings
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (PatternManager.Instance.GetComponent<CatSpriteChanger>() != null) { CatSpriteChanger.Instance.CatEarlyOrLate(); }
                SendPlayerArrowInput(Arrows.Up, 0, Player.Instance.canPress);
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (PatternManager.Instance.GetComponent<CatSpriteChanger>() != null) { CatSpriteChanger.Instance.CatEarlyOrLate(); }
                SendPlayerArrowInput(Arrows.Down, 1, Player.Instance.canPress);
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (PatternManager.Instance.GetComponent<CatSpriteChanger>() != null) { CatSpriteChanger.Instance.CatEarlyOrLate(); }
                SendPlayerArrowInput(Arrows.Left, 2, Player.Instance.canPress);
                playerPressMissEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(PatternManager.Instance.GetComponent<CatSpriteChanger>() != null) { CatSpriteChanger.Instance.CatEarlyOrLate(); }
                SendPlayerArrowInput(Arrows.Right, 3, Player.Instance.canPress);
                playerPressMissEvent.Invoke();
            }
        }
    }
    public void SendPlayerArrowInput(Arrows arrow, int x, bool canPress)
    {
        PatternManager.Instance.GetComponent<PatternManager>().ReceivePlayerArrowInput(arrow, x, canPress);
    }
}
