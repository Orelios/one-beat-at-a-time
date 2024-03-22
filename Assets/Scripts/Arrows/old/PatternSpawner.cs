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
    private int numOfCorrectArrows = 0;

    private void Awake()
    {
        for (int i = 0; i < _patterns[lengthChecker].iconPatterns.Length; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[lengthChecker].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
    public void SpawnPatterns()
    {
        if (readyToChangePattern == true && lengthChecker < _patterns.Length - 1)
        {
            lengthChecker++;
            for (int i = 0; i < _patterns[lengthChecker].iconPatterns.Length; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                    = _patterns[lengthChecker].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            }
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
    public void PlayerArrowInputs(Arrows arrows)
    {
        if (arrows == Arrows.Up)
        {
            //InputArrowSpriteChanger(0, Arrows.Up);
            arrowInputs[playerArrowInputCount] = arrows;
            CheckPattern(0, arrows);
        }
        else if (arrows == Arrows.Left)
        {
            //InputArrowSpriteChanger(2, Arrows.Left);
            arrowInputs[playerArrowInputCount] = arrows;
            CheckPattern(2, arrows);
        }
        else if (arrows == Arrows.Right)
        {
            arrowInputs[playerArrowInputCount] = arrows;
            CheckPattern(3, arrows);
            //InputArrowSpriteChanger(3, Arrows.Right);
        }
        else if (arrows == Arrows.Down)
        {
            arrowInputs[playerArrowInputCount] = arrows;
            CheckPattern(1, arrows);
            //InputArrowSpriteChanger(1, Arrows.Down);
        }
        //CheckPattern(); 

    }
    public void CheckPattern(int arrowSprite, Arrows arrow)
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
        if (arrowInputs[playerArrowInputCount] == _patterns[lengthChecker].arrowsPattern[playerArrowInputCount])
        {
            PlayerInputPattern.Instance.reset -= 1;
            checkTimingValue();
            InputArrowSpriteChanger(arrowSprite);
            playerArrowInputCount += 1;
            numOfCorrectArrows += 1;
            PlayerInputPattern.Instance.CheckPlayerInputSprites();
        
        }
        else
        {
            PlayerInputPattern.Instance.reset += 1;
            //playerArrowInputCount += 1;
            playerArrowInputCount = 0;
            numOfCorrectArrows = 0;
            PlayerInputPattern.Instance.CheckPlayerInputSprites();
            resetWrongPlayerArrowInput();
        }
        if (numOfCorrectArrows == 4)
        {
            GetComponent<PulseToTheBeat>().Pulse();
            for (int i = 0; i < PlayerInputPattern.Instance.GetComponent<PlayerArrowInput>().patternSpawner.Length; i++)
            {
                PlayerInputPattern.Instance.GetComponent<PlayerArrowInput>().patternSpawner[i].resetPlayerArrowInput();
                PlayerInputPattern.Instance.GetComponent<PlayerArrowInput>().patternSpawner[i].playerArrowInputCount = 0;
                PlayerInputPattern.Instance.GetComponent<PlayerArrowInput>().patternSpawner[i].numOfCorrectArrows = 0;
                PlayerInputPattern.Instance.GetComponent<PlayerArrowInput>().patternSpawner[i].readyToChangePattern = true;
                PlayerInputPattern.Instance.GetComponent<PlayerArrowInput>().patternSpawner[i].SpawnPatterns();
            }
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
    public void InputArrowSpriteChanger(int arrowSprite)
    {
        PlayerInputPattern.Instance.gameObject.transform.GetChild(playerArrowInputCount).GetComponent<SpriteRenderer>().sprite =
                PlayerInputPattern.Instance.playerInputPattens[arrowSprite].GetComponent<SpriteRenderer>().sprite;
    }

    public void checkTimingValue()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            //PlayerInputPattern.Instance.GetComponent<BarManipulator>().AddSmall();
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            //PlayerInputPattern.Instance.GetComponent<BarManipulator>().AddMedium();
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
           // PlayerInputPattern.Instance.GetComponent<BarManipulator>().AddSmall();
        }
    }
}
