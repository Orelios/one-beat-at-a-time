using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{
    [SerializeField] private PatternsScriptableObjects[] _patterns;
    public Arrows[] arrowInputs;

    [System.NonSerialized] public bool readyToChangePattern = true;
    private int lengthChecker = 0;
    private int playerArrowInputCount = 0;
    private int numOfCorrectPatterns = 0;
    private GameObject playerInputPatterns; 
    
    private void Awake()
    {
        SpawnPatterns();
        playerInputPatterns = GameObject.Find("PlayerInputPatterns");
    }
    public void SpawnPatterns()
    {
        if(readyToChangePattern == true && lengthChecker < _patterns.Length)
        {     
            for (int i = 0; i < _patterns[lengthChecker].iconPatterns.Length; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite 
                    = _patterns[lengthChecker].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            }

            lengthChecker++;
            readyToChangePattern = false;
        }
        else //if pattern list finished
        {
            //nullify all sprites
            for (int i = 0; i < _patterns[lengthChecker - 1].iconPatterns.Length; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                    = null; 
            }
            readyToChangePattern = false;
            EndRhythmScreen.Instance.StopGame(); //call EndScreen to stop game
        }

    }
    public void PlayerArrowInputs(Arrows arrows, int playerInputCount)
    {
        if (arrows == Arrows.Up)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 0, Arrows.Up); 
            playerArrowInputCount += playerInputCount;
        }
        else if (arrows == Arrows.Left)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 2, Arrows.Left);
            playerArrowInputCount += playerInputCount;
        }
        else if (arrows == Arrows.Right)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 3, Arrows.Right);
            playerArrowInputCount += playerInputCount;
        }
        else if (arrows == Arrows.Down)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 1, Arrows.Down);
            playerArrowInputCount += playerInputCount;
        }
        if (playerArrowInputCount == 4)
        {
            CheckPattern(); 
        }

    }
    public void CheckPattern()
    {
        //This will check if you had inputed the right pattern
        //This will also clear the player inputs and reset PlayerArrowInputCount to 0 again
        //This will also take in the function SpawnPatterns()
        //This will also make the readyToChangePattern = true 
        for(int i = 0; i < 4; i++)
        {
            if (arrowInputs[i] == _patterns[lengthChecker - 1].arrowsPattern[i])
            {
                numOfCorrectPatterns++;
                //Debug.Log(numOfCorrectPatterns);
            }
        }
        if(numOfCorrectPatterns == 4)
        {
            numOfCorrectPatterns = 0;
            playerArrowInputCount = 0;
            GetComponent<PulseToTheBeat>().Pulse();

            for (int i = 0; i < playerInputPatterns.GetComponent<PlayerArrowInput>().patternSpawner.Length; i++)
            {
                playerInputPatterns.GetComponent<PlayerArrowInput>().patternSpawner[i].readyToChangePattern = true; 
                playerInputPatterns.GetComponent<PlayerArrowInput>().patternSpawner[i].SpawnPatterns();
                playerInputPatterns.GetComponent<PlayerArrowInput>().patternSpawner[i].resetPlayerArrowInput(); 
            } 
        }
        else
        {
            numOfCorrectPatterns = 0;
            playerArrowInputCount = 0;
            resetPlayerArrowInput(); 
        }
    }
    public void resetPlayerArrowInput()
    {
        for(int i = 0; i < 4; i++)
        {
            PlayerInputPattern.Instance.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
               null;

            arrowInputs[i] = Arrows.None;
        }
    }  
    public void InputArrowSpriteChanger(int playerArrowInputCounter, int arrowSprite, Arrows arrow)
    {
        PlayerInputPattern.Instance.gameObject.transform.GetChild(playerArrowInputCounter).GetComponent<SpriteRenderer>().sprite =
                PlayerInputPattern.Instance.playerInputPattens[arrowSprite].GetComponent<SpriteRenderer>().sprite;

        arrowInputs[playerArrowInputCounter] = arrow;
    }
}
