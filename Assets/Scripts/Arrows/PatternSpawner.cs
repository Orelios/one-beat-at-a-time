using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSpawner : MonoBehaviour
{
    [SerializeField] private PatternsScriptableObjects[] _patterns;
    public Arrows[] arrowInputs;

    [System.NonSerialized] public bool readyToChangePattern = false;
    private int lengthChecker = 0;
    private int playerArrowInputCount = 0;
    private int numOfCorrectPatterns = 0;
    private GameObject playerInputPatterns;

    private void Awake()
    {
        for (int i = 0; i < _patterns[lengthChecker].iconPatterns.Length; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[lengthChecker].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
        playerInputPatterns = GameObject.Find("PlayerInputPatterns");
    }
    public void SpawnPatterns()
    {
        Debug.Log(lengthChecker + " < " + _patterns.Length);
        if (readyToChangePattern == true && lengthChecker < _patterns.Length - 1)
        {
            lengthChecker++;
            for (int i = 0; i < _patterns[lengthChecker].iconPatterns.Length; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                    = _patterns[lengthChecker].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            }
            //lengthChecker++;
            readyToChangePattern = false;
        }
        else
        {
            lengthChecker = 0;
            for (int i = 0; i < _patterns[lengthChecker].iconPatterns.Length; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                    = _patterns[lengthChecker].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            }
            readyToChangePattern = false;
        }
    }
    public void PlayerArrowInputs(Arrows arrows, int playerInputCount)
    {
        if (arrows == Arrows.Up)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 0, Arrows.Up);
            //playerArrowInputCount += playerInputCount;
        }
        else if (arrows == Arrows.Left)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 2, Arrows.Left);
            //playerArrowInputCount += playerInputCount;
        }
        else if (arrows == Arrows.Right)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 3, Arrows.Right);
            //playerArrowInputCount += playerInputCount;
        }
        else if (arrows == Arrows.Down)
        {
            InputArrowSpriteChanger(playerArrowInputCount, 1, Arrows.Down);
            //playerArrowInputCount += playerInputCount;
        }
        CheckPattern(playerInputCount); 

    }
    public void CheckPattern(int playerInputCount)
    {
        //This will check if you had inputed the right pattern
        //This will also clear the player inputs and reset PlayerArrowInputCount to 0 again
        //This will also take in the function SpawnPatterns()
        //This will also make the readyToChangePattern = true 
        /*
        for (int i = 0; i < 4; i++)
        {
            if (arrowInputs[i] == _patterns[lengthChecker].arrowsPattern[i])
            {
                numOfCorrectPatterns++;
                //Debug.Log(numOfCorrectPatterns);
            }
        }
        */
        //Checks if player
        if(arrowInputs[playerArrowInputCount] == _patterns[lengthChecker].arrowsPattern[playerArrowInputCount])
        {
            PlayerInputPattern.Instance.reset -= 1; 
            checkTimingValue();
            playerArrowInputCount += playerInputCount; 
        }
        else
        {
            PlayerInputPattern.Instance.reset += 1;
            playerArrowInputCount += playerInputCount;
            //resetWrongPlayerArrowInput(); 
        }
        //To revamp as well dont make it dependent on if numOfCorrectPatterns == 4
        if (playerArrowInputCount == 4)
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
            readyToChangePattern = false;
            //playerArrowInputCount = 0;
            //resetPlayerArrowInput();
        }
    }
    public void resetPlayerArrowInput()
    {
        for (int i = 0; i < 4; i++)
        {
            PlayerInputPattern.Instance.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite =
               null;

            arrowInputs[i] = Arrows.None;
        }
    }
    public void resetWrongPlayerArrowInput()
    {
        for (int i = 0; i < 4; i++)
        {
            arrowInputs[i] = Arrows.None;
        }
    }
    public void InputArrowSpriteChanger(int playerArrowInputCounter, int arrowSprite, Arrows arrow)
    {
        PlayerInputPattern.Instance.gameObject.transform.GetChild(playerArrowInputCounter).GetComponent<SpriteRenderer>().sprite =
                PlayerInputPattern.Instance.playerInputPattens[arrowSprite].GetComponent<SpriteRenderer>().sprite;

        arrowInputs[playerArrowInputCounter] = arrow;
    }

    public void checkTimingValue()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            PlayerInputPattern.Instance.GetComponent<ProgressBarManipulator>().AddSmall();
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            PlayerInputPattern.Instance.GetComponent<ProgressBarManipulator>().AddMedium();
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
            PlayerInputPattern.Instance.GetComponent<ProgressBarManipulator>().AddSmall();
        }
    }
}
