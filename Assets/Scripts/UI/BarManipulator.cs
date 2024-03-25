using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManipulator : Singleton<BarManipulator>
{
    public ProgressBar progressBar;
    public FocusBar focusBar;
    public NoteDetection detector;
    public bool _changeBar = false;
    public GameObject[] studyBubbleObjects; //create empty object with children each containing a sprite
    public GameObject[] focusBubbleObjects;
    public Bars barEnum = Bars.Focus;
    public int studyBubbleIndex = 0, focusBubbleIndex = 0;
    //[SerializeField] private bool perArrow = false;
    //[SerializeField] private bool perPattern = false;
    private void Awake()
    {
        progressBar.currentProgressBarIndicator.gameObject.SetActive(true);
        focusBar.currentFocusBarIndicator.gameObject.SetActive(false);
    }
    private void Update()
    {
        ChangeBar(); 
    }

    public void ChangeBar()
    {
        if(Player.Instance.canPress == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (PatternManager.Instance._patternIndex >= PatternManager.Instance._patterns.Length - 1)
                {
                    PatternManager.Instance.LoopPatternArray();
                }
                else
                {
                    PatternManager.Instance.StartCoroutine(PatternManager.
                        Instance.Pulse(PatternManager.Instance._patternCurrent));
                }
                if (_changeBar == false) //will change to focus bar
                {
                    _changeBar = true;
                    PatternManager.Instance.ChangeBar(_changeBar);
                    progressBar.currentProgressBarIndicator.gameObject.SetActive(false);
                    focusBar.currentFocusBarIndicator.gameObject.SetActive(true);
                    barEnum = Bars.Focus;
                }
                else if(_changeBar == true) // will change to progress bar
                { 
                    _changeBar = false;
                    PatternManager.Instance.ChangeBar(_changeBar);
                    progressBar.currentProgressBarIndicator.gameObject.SetActive(true);
                    focusBar.currentFocusBarIndicator.gameObject.SetActive(false);
                    barEnum = Bars.Study;
                }
                detector.DestroyNote();
                Debug.Log(_changeBar);
            }
        }
    }

    public void AddSmall(bool changeBar)
    {
        if (changeBar == false) { progressBar.AddProgressSmall(); }
        else if(changeBar == true) { focusBar.AddProgressSmall(); }
    }

    public void AddMedium(bool changeBar)
    {
        if (changeBar == false) { progressBar.AddProgressMedium();}
        else if (changeBar == true) { focusBar.AddProgressMedium(); }
    }

    public void AddLarge(bool changeBar)
    {
        if (changeBar == false) { progressBar.AddProgressLarge();}
        else if (changeBar == true) { focusBar.AddProgressLarge(); }
    }

    public void SubtractSmall(bool changeBar)
    {
        if (changeBar == false) { progressBar.SubtractProgressSmall(); }
        else if (changeBar == true) { focusBar.SubtractProgressSmall(); }
    }

    public void SubtractMedium(bool changeBar)
    {
        if (changeBar == false) { progressBar.SubtractProgressMedium(); }
        else if (changeBar == true) { focusBar.SubtractProgressMedium(); }
    }

    public void SubtractLarge(bool changeBar)
    {
        if (changeBar == false) { progressBar.SubtractProgressLarge(); }
        else if (changeBar == true) { focusBar.SubtractProgressLarge(); }
    }

    public enum Bars
    {
        Study,
        Focus
    }

    public void CycleStudyBubbleIndex()
    {
        studyBubbleIndex += 1;
        if (studyBubbleIndex >= studyBubbleObjects.Length)
        {
            studyBubbleIndex = 0;
        }
    }

    public void CycleFocusBubbleIndex()
    {
        focusBubbleIndex += 1;
        if (focusBubbleIndex >= focusBubbleObjects.Length)
        {
            focusBubbleIndex = 0;
        }
    }
}
