using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : Singleton<PatternManager>
{
    [SerializeField] private Sprite[] _correctArrowSprites; //must be set in inspector UP/DOWN/LEFT/RIGHT
    [SerializeField] private Sprite[] _incorrectArrowSprites; //must be set in inspector UP/DOWN/LEFT/RIGHT
    [SerializeField] private Arrows[] _arrowInputEnums; //for pattern comparison later - can delete if not needed
    [SerializeField] private PatternsScriptableObjects[] _patterns;
    private GameObject _patternCurrent, _patternPreview, _patternSliding;
    private int _patternIndex = 0, _arrowIndex = 0;
    private Vector3 _slideStartPos, _slideEndPos;
    private Vector3 _slideStartScale, _slideEndScale;
    [SerializeField] private float _slideDuration = 0.5f;
    private float _elapsedTime;

    void Awake()
    {
        _patternCurrent = this.gameObject.transform.GetChild(0).gameObject;
        _patternPreview = this.gameObject.transform.GetChild(1).gameObject;
        _patternSliding = this.gameObject.transform.GetChild(2).gameObject;

        _slideStartPos = _patternPreview.transform.position;
        _slideEndPos = _patternCurrent.transform.position;
        _slideStartScale = _patternPreview.transform.localScale;
        _slideEndScale = _patternCurrent.transform.localScale;

        for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
        {
            _patternCurrent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            _patternPreview.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            _patternSliding.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
        //StartCoroutine(TestSlide());
    }

    private void Update()
    {
        //for testing purposes. can be removed
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextPatternSequence();
        }
    }

    public void ReceivePlayerArrowInput(Arrows arrow, int x)
    {
        _arrowInputEnums[_arrowIndex] = arrow;//for pattern comparison later - can delete if not needed
        //if arrow is correct, change arrow sprite to pressedArrowSprite
        //pressedArrowSprite is an indicator that means the arrow was detected as correct
        if (_patterns[_patternIndex].arrowsPattern[_arrowIndex] == arrow)
        {
            _patternCurrent.transform.GetChild(_arrowIndex).GetComponent<SpriteRenderer>().sprite
                = _correctArrowSprites[x];
            _arrowIndex += 1;
        }
        else //wrong arrow pressed, auto next pattern
        {
            _patternCurrent.transform.GetChild(_arrowIndex).GetComponent<SpriteRenderer>().sprite
                = _incorrectArrowSprites[x]; //change current ARROW to wrong version
            _patternCurrent.GetComponent<PulseToTheBeat>().Pulse(); //pulse the pattern
            _arrowIndex = 0;
            NextPatternSequence(); //AFTER pulse finishes
        }

        if (_arrowIndex >= 4)
        {
            _arrowIndex = 0;
            _patternIndex += 1;
            //NextPatternSequence();
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
            for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
            {
                pattern.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                    = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            }
        }
        else if (pattern.gameObject.name == "PatternPreview" || (pattern.gameObject.name == "PatternSliding"))
        {
            //uses _patterns[_patternIndex + 1] to show the "preview" pattern
            for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
            {
                pattern.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                    = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
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
            pattern.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
    #endregion

    public void RemoveSprites(GameObject pattern)
    {
        for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
        {
            pattern.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    #region TestSlide
    private IEnumerator TestSlide() //general version. won't be used
    {
        //_patternSliding only - slide down and inc size
        _elapsedTime = 0;
        while (_elapsedTime < _slideDuration)
        {
            _elapsedTime += Time.deltaTime;
            float percentCompleted = _elapsedTime / _slideDuration;
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
        _elapsedTime = 0;
        while (_elapsedTime < _slideDuration)
        {
            _elapsedTime += Time.deltaTime;
            float percentCompleted = _elapsedTime / _slideDuration;
            _patternSliding.transform.position = Vector3.Lerp(_slideStartPos, _slideEndPos, percentCompleted);
            _patternSliding.transform.localScale = Vector3.Lerp(_slideStartScale, _slideEndScale, percentCompleted);
            //when finished, must change position to original and change back to original size
            yield return null;
        }
        //when _patternSliding reaches _patternCurrent position, _patternSliding remove sprites, move back, change size
        _patternSliding.transform.position = _slideStartPos;
        _patternSliding.transform.localScale = _slideStartScale;
        SpawnPattern(_patternCurrent); //gives illusion that _patternSliding becomes new pattern to follow
        SpawnPattern(_patternSliding); //this will be behind _patternPreview
    }

    public void NextPatternSequence()
    {
        RemoveSprites(_patternCurrent);
        StartCoroutine(SlideSequenceVersion()); //slide down and inc size
        _patternIndex += 1;
        SpawnPattern(_patternPreview); //done after coroutine starts so they don't overlap
        //when _patternSliding reaches _patternCurrent position, _patternSliding remove sprites, move back, change size
        //SpawnPattern(_patternCurrent); //gives illusion that _patternSliding becomes new pattern to follow
        //SpawnPattern(_patternSliding); //this will be behind _patternPreview
    }
}
