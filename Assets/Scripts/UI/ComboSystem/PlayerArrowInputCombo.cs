using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerArrowInputCombo : MonoBehaviour
{
    public NoteDetection detector;
    public PatternSpawner[] patternSpawner;
    private Arrows arrows;
    public UnityEvent playerPressEvent;
    public UnityEvent playerPressSpaceEvent;
    public float inputCooldown;
    void Update()
    {
        DetectArrowInput();
        if (Player.Instance.inputCooldown != 0)
        {
            Player.Instance.inputCooldown -= Time.deltaTime;
            if (Player.Instance.inputCooldown < 0) { Player.Instance.inputCooldown = 0; }
        }
    }

    public void DetectArrowInput() //Need to figure out the whole space bar thing
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Player.Instance.inputCooldown == 0)
            {
                SendPlayerArrowInput(Arrows.Up, 0);
                playerPressEvent.Invoke(); //change this because it deletes notes 
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SendPlayerArrowInput(Arrows.Down, 1);
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SendPlayerArrowInput(Arrows.Left, 2);
                playerPressEvent.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SendPlayerArrowInput(Arrows.Right, 3);
                playerPressEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PatternManagerCombo.Instance.ReleaseCombo();
                playerPressSpaceEvent.Invoke(); 
                //Add playerSpaceEvent where notes are destroyed and other cool shit happens
            }
        }     
    }
    public void SendPlayerArrowInput(Arrows arrow, int x)
    {
        PatternManagerCombo.Instance.GetComponent<PatternManagerCombo>().ReceivePlayerArrowInput(arrow, x);
    }
}
