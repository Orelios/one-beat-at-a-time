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
    public float inputCooldownAmount; 
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
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Player.Instance.inputCooldown == 0)
            {
                SendPlayerArrowInput(Arrows.Up, 0);
                playerPressEvent.Invoke(); //change this because it deletes notes 
                Player.Instance.inputCooldown = inputCooldownAmount;
                //StartCoroutine(WaitTime());
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && Player.Instance.inputCooldown == 0)
            {
                SendPlayerArrowInput(Arrows.Down, 1);
                playerPressEvent.Invoke();
                Player.Instance.inputCooldown = inputCooldownAmount;
                //StartCoroutine(WaitTime());
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Player.Instance.inputCooldown == 0)
            {
                SendPlayerArrowInput(Arrows.Left, 2);
                playerPressEvent.Invoke();
                Player.Instance.inputCooldown = inputCooldownAmount;
                //StartCoroutine(WaitTime());
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && Player.Instance.inputCooldown == 0)
            {
                SendPlayerArrowInput(Arrows.Right, 3);
                playerPressEvent.Invoke();
                Player.Instance.inputCooldown = inputCooldownAmount;
                //StartCoroutine(WaitTime());
            }

            if (Input.GetKeyDown(KeyCode.Space) && Player.Instance.inputCooldown == 0)
            {
                PatternManagerCombo.Instance.ReleaseCombo();
                playerPressSpaceEvent.Invoke();
                Player.Instance.inputCooldown = inputCooldownAmount;
                //StartCoroutine(WaitTime());
                //Add playerSpaceEvent where notes are destroyed and other cool shit happens
            }
        }     
    }
    public void SendPlayerArrowInput(Arrows arrow, int x)
    {
        PatternManagerCombo.Instance.GetComponent<PatternManagerCombo>().ReceivePlayerArrowInput(arrow, x);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
    }
}
