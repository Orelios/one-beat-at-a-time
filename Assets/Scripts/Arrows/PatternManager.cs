using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : Singleton<PatternManager>
{
    [SerializeField] private Sprite[] _pressedArrowSprites;
    [SerializeField] private Arrows[] _arrowInputEnums;
    [SerializeField] private PatternsScriptableObjects[] _patterns;
    private GameObject _patternCurrent, _patternPreview, _patternSliding;
    private int _patternIndex = 0, _arrowIndex = 0;
    void Awake()
    {
        _patternCurrent = this.gameObject.transform.GetChild(0).gameObject;
        _patternPreview = this.gameObject.transform.GetChild(1).gameObject;
        _patternSliding = this.gameObject.transform.GetChild(2).gameObject;
        for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
        {
            _patternCurrent.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            _patternPreview.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
            _patternSliding.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex + 1].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
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
                = _pressedArrowSprites[x];
            _arrowIndex += 1;
        }
        else
        {
            _arrowIndex = 0;
            //insert function to reset sprites
        }
    }

    public void SpawnNextPattern(GameObject pattern)
    {
        //_patternIndex += 1;
        //this function assumes _patternIndex has been incremented by 1
        //patterns are to be "spawned" at different times and will thus be individually called with this function,
            //so _patternIndex is not incremented within this function to avoid unintended increments
        for (int i = 0; i < _patterns[_patternIndex].iconPatterns.Length; i++)
        {
            pattern.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite
                = _patterns[_patternIndex].iconPatterns[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
