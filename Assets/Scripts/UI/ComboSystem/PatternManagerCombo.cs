using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class PatternManagerCombo : Singleton<PatternManagerCombo>
{
    [SerializeField] private Sprite[] _correctArrowSprites; //must be set in inspector UP/DOWN/LEFT/RIGHT
    [SerializeField] private Sprite[] _incorrectArrowSprites; //must be set in inspector UP/DOWN/LEFT/RIGHT/MISS
    public Sprite blank;
    [SerializeField] private Arrows[] _arrowInputEnums; //for pattern comparison later - can delete if not needed
    public PatternsScriptableObjects[] _patterns;
    [System.NonSerialized] public GameObject _patternCurrent, _patternPreview, _patternSliding;
    [System.NonSerialized] public int _patternIndex = 0, _arrowIndex = 0;
    private Vector3 _slideStartPos, _slideEndPos;
    private Vector3 _slideStartScale, _slideEndScale;
    [SerializeField] private float _slideDuration = 0.5f, _pulseDuration = 0.5f;
    [SerializeField] private float _pulseSizeMultiplier = 1.15f;
    private float _slideElapsedTime, _pulseElapsedTime;
    private bool _changeBar;
    private bool lastCorrectArrowPressed = false; 

    public UnityEvent addToComboEvent;
    public UnityEvent ResetComboEvent;
    public UnityEvent spacePressEvent;
    public UnityEvent spaceMissPressEvent; 
    void Awake()
    {
        _patternCurrent = this.gameObject.transform.GetChild(0).gameObject;
        _patternPreview = this.gameObject.transform.GetChild(1).gameObject;
        _patternSliding = this.gameObject.transform.GetChild(2).gameObject;

        _slideStartPos = _patternPreview.transform.localPosition;
        _slideEndPos = _patternCurrent.transform.localPosition;
        _slideStartScale = _patternPreview.transform.localScale;
        _slideEndScale = _patternCurrent.transform.localScale;

        for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
        {
            _patternCurrent.transform.GetChild(i).GetComponent<Image>().sprite
                = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            _patternPreview.transform.GetChild(i).GetComponent<Image>().sprite
                = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            _patternSliding.transform.GetChild(i).GetComponent<Image>().sprite
                = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
        //StartCoroutine(TestSlide());
    }

    public void ReceivePlayerArrowInput(Arrows arrow, int x)
    {
        //if arrow is correct, change arrow sprite to pressedArrowSprite
        //pressedArrowSprite is an indicator that means the arrow was detected as correct
        if (_patterns[_patternIndex].arrowsPattern[_arrowIndex] == arrow) //THIS WILL HAVE THE ADD TO COMBO METER
        {
            //IndicatorAboveImage.Instance.ChangeAboveIndicatorImage();
            _patternCurrent.transform.GetChild(_arrowIndex).GetComponent<Image>().sprite
                = _correctArrowSprites[x];
            addToComboEvent.Invoke();
            _arrowIndex++;

            if(_arrowIndex == 4)
            {
                if (_patternIndex >= _patterns.Length - 1) //if last pattern and last arrow
                {
                    LoopPatternArray();
                }
                else //last arrow but not last pattern
                {
                    StartCoroutine(Pulse(_patternCurrent));
                }
            }
        }
        else if (_patterns[_patternIndex].arrowsPattern[_arrowIndex] != arrow) //wrong arrow pressed, auto next pattern
        {
            if (_patternIndex < _patterns.Length - 1)
            {
                //IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
                _patternCurrent.transform.GetChild(_arrowIndex).GetComponent<Image>().sprite
                    = _incorrectArrowSprites[x]; //change current ARROW to wrong version
                                                 //Decreases the current tabbed bar. The amoun that is decreased depends on the timing value
                if (_patterns[_patternIndex].arrowsPattern[_arrowIndex] != arrow) { checkTimingValueDec(); }
                StartCoroutine(Pulse(_patternCurrent)); //pulse the pattern
                                                        //NextPatternSequence is called after pulse finishes inside Pulse coroutine
                                                        //Debug.Log("incorrect");
                ResetComboEvent.Invoke();
                spaceMissPressEvent.Invoke();
            }
            else //last pattern wrong arrow pressed
            {
                //IndicatorAboveImage.Instance.MissChangeAboveIndicatorImage();
                _patternCurrent.transform.GetChild(_arrowIndex).GetComponent<Image>().sprite
                    = _incorrectArrowSprites[x]; //change current ARROW to wrong version
                if (_patterns[_patternIndex].arrowsPattern[_arrowIndex] != arrow) { checkTimingValueDec(); }
                LoopPatternArray();
                ResetComboEvent.Invoke();
                spaceMissPressEvent.Invoke();
            }
        }
        


    }

    public void ReleaseCombo()
    {
        //Debug.Log(Player.Instance.canPress);
        if (Player.Instance.canPress == true )
        {

            if (_patternIndex >= _patterns.Length - 1) //if last pattern and last arrow
            {
                LoopPatternArray();
            }
            else //last arrow but not last pattern
            {
                StartCoroutine(Pulse(_patternCurrent));
                //NextPatternSequence is called after pulse finishes inside Pulse coroutine
                //Debug.Log("pattern complete");
            }
            checkTimingValueInc();
            ResetComboEvent.Invoke();
            spacePressEvent.Invoke(); 
            Player.Instance.canPress = true;
        }
        else if (Player.Instance.canPress == false)
        {
            if (_patternIndex >= _patterns.Length - 1) //if last pattern and last arrow
            {
                LoopPatternArray();
            }
            else //last arrow but not last pattern
            {
                StartCoroutine(Pulse(_patternCurrent));
            }
            ResetComboEvent.Invoke();
            spaceMissPressEvent.Invoke(); 
            Player.Instance.canPress = false;
            //maybe put a little popup text where it states that you missed so the combo thing resets 
        }
    }

    public void SpawnPattern(GameObject pattern)
    {
        //_patternIndex += 1;
        //this function assumes _patternIndex has been incremented by 1
        //patterns are to be "spawned" at different times and will thus be individually called with this function,
        //so _patternIndex is not incremented within this function to avoid unintended increments
        if (pattern.gameObject.name == "PatternCurrent")
        {
            for (int i = 0; i < _patterns[0].iconPatterns.Length; i++) //uses _patterns[0] because _patternIndex is irrelevant, only needs iconPatterns.Length
            {
                pattern.transform.GetChild(i).GetComponent<Image>().sprite
                    = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            }
        }
        else if (pattern.gameObject.name == "PatternPreview" || (pattern.gameObject.name == "PatternSliding"))
        {
            if (_patternIndex < _patterns.Length - 1)
            {
                for (int i = 0; i < _patterns[0].iconPatterns.Length; i++) //uses _patterns[0] because _patternIndex is irrelevant, only needs iconPatterns.Length
                {
                    //uses _patterns[_patternIndex + 1] to show the "preview" pattern
                    pattern.transform.GetChild(i).GetComponent<Image>().sprite
                        = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
                }
            }
            else
            {
                for (int i = 0; i < _patterns[0].iconPatterns.Length; i++) //uses _patterns[0] because _patternIndex is irrelevant, only needs iconPatterns.Length
                {
                    //uses _patterns[0] to show the first pattern as in a loop
                    pattern.transform.GetChild(i).GetComponent<Image>().sprite
                        = _patterns[0].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
                }
            }

        }
    }

    #region ResetPattern
    //might not be needed since if incorrect arrow was pressed, proceed to next pattern instead of resetting
    public void ResetPattern(GameObject pattern)
    {
        //ResetPattern(_patternCurrent);
        //_patternCurrent only
        //change _correctArrowSprites back to _patterns sprites
        for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
        {
            pattern.transform.GetChild(i).GetComponent<Image>().sprite
                = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
    #endregion

    public void RemoveSprites(GameObject pattern)
    {
        for (int i = 0; i < _patterns[0].iconPatterns.Length; i++) //uses _patterns[0] because _patternIndex is irrelevant, only needs iconPatterns.Length
        {
            pattern.transform.GetChild(i).GetComponent<Image>().sprite = blank;
        }
    }

    #region TestSlide
    private IEnumerator TestSlide() //general version. won't be used
    {
        //_patternSliding only - slide down and inc size
        _slideElapsedTime = 0;
        while (_slideElapsedTime < _slideDuration)
        {
            _slideElapsedTime += Time.deltaTime;
            float percentCompleted = _slideElapsedTime / _slideDuration;
            _patternSliding.transform.position = Vector3.Lerp(_slideStartPos, _slideEndPos, percentCompleted);
            _patternSliding.transform.localScale = Vector3.Lerp(_slideStartScale, _slideEndScale, percentCompleted);
            //when finished, must change position to original and change back to original size
            yield return null;
        }
        //Debug.Log("coroutine end");
    }
    #endregion

    private IEnumerator SlideSequenceVersion() //will be called in NextPatternSequence()
    {
        _slideElapsedTime = 0;
        while (_slideElapsedTime < _slideDuration)
        {
            _slideElapsedTime += Time.deltaTime;
            float percentCompleted = _slideElapsedTime / _slideDuration;
            _patternSliding.transform.localPosition = Vector3.Lerp(_slideStartPos, _slideEndPos, percentCompleted);
            _patternSliding.transform.localScale = Vector3.Lerp(_slideStartScale, _slideEndScale, percentCompleted);
            //when finished, must change position to original and change back to original size
            yield return null;
        }
        //when _patternSliding reaches _patternCurrent position, _patternSliding remove sprites, move back, change size
        _patternSliding.transform.localPosition = _slideStartPos;
        _patternSliding.transform.localScale = _slideStartScale;
        SpawnPattern(_patternCurrent); //gives illusion that _patternSliding becomes new pattern to follow
        SpawnPattern(_patternSliding); //this will be behind _patternPreview
    }

    public void NextPatternSequence()
    {
        RemoveSprites(_patternCurrent);
        StartCoroutine(SlideSequenceVersion()); //slide down and inc size
        _patternIndex += 1; //MUST occur before sliding ends and SpawnPattern(_patternCurrent) and SpawnPattern(_patternSliding) are called
        SpawnPattern(_patternPreview); //done after coroutine starts so they don't overlap
        //when _patternSliding reaches _patternCurrent position, _patternSliding remove sprites, move back, change size
        //SpawnPattern(_patternCurrent); //gives illusion that _patternSliding becomes new pattern to follow
        //SpawnPattern(_patternSliding); //this will be behind _patternPreview
    }

    public IEnumerator Pulse(GameObject pattern)
    {
        _arrowIndex = 0;
        _pulseElapsedTime = 0;
        Vector3 endScale = pattern.transform.localScale;
        Vector3 startScale = pattern.transform.localScale * _pulseSizeMultiplier;
        while (_pulseElapsedTime < _pulseDuration)
        {
            _pulseElapsedTime += Time.deltaTime;
            float percentageCompleted = _pulseElapsedTime / _pulseDuration;
            pattern.transform.localScale = Vector3.Lerp(startScale, endScale, percentageCompleted);
            yield return null;
        }
        NextPatternSequence(); //AFTER pulse finishes
    }

    public void LoopPatternArray()
    {
        _patternIndex = -1; //to account for increment in NextPatternSequence()
        StartCoroutine(Pulse(_patternCurrent));
        //NextPatternSequence is called after pulse finishes inside Pulse coroutine
        //Debug.Log("pattern loop");
    }
    public void ChangeBar(bool changeBar)
    {
        _changeBar = changeBar;
    }
    public void checkTimingValueInc()
    {
        BarManipulatorWithCombo.Instance.AddCombo(); 
    }
    public void checkTimingValueDec()
    {
        if (GetComponent<BarManipulator>() != null) { BarManipulator.Instance.SubtractMedium(_changeBar); }
        else if (GetComponent<BarManipulatorNoTab>() != null) { BarManipulatorNoTab.Instance.PlayerMiss(); }
        else if(GetComponent<BarManipulatorWithCombo>() != null) { BarManipulatorWithCombo.Instance.PlayerMiss(); }
    }
    public void Miss()
    {
        if (GetComponent<BarManipulator>() != null) //BarManipulator is attached
        {
            checkTimingValueDec();
        }
        else if (GetComponent<BarManipulatorNoTab>() != null) //BarManipulatorNoTab is used
        {
            BarManipulatorNoTab.Instance.PlayerMiss();
        }
        else if (GetComponent<BarManipulatorWithCombo>() != null) { BarManipulatorWithCombo.Instance.PlayerMiss(); }
    }
}