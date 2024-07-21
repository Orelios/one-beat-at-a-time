using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    private Color visible, invisible;
    private float fadeElapsedTime = 0f;
    public float fadeDuration = 0.5f;
    private float inputCooldown = 1; 
    //[SerializeField] private bool perArrow = false;
    //[SerializeField] private bool perPattern = false;
    private void Awake()
    {
        progressBar.currentProgressBarIndicator.gameObject.SetActive(true);
        focusBar.currentFocusBarIndicator.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Player.Instance.inputCooldown != 0)
        {
            Player.Instance.inputCooldown -= Time.deltaTime;
            if (Player.Instance.inputCooldown < 0) { Player.Instance.inputCooldown = 0; }
        }
        ChangeBar();
    }

    public void ChangeBar()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Player.Instance.inputCooldown == 0)
        {
            AddInputCoolDown();
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
            else if (_changeBar == true) // will change to progress bar
            {
                _changeBar = false;
                PatternManager.Instance.ChangeBar(_changeBar);
                progressBar.currentProgressBarIndicator.gameObject.SetActive(true);
                focusBar.currentFocusBarIndicator.gameObject.SetActive(false);
                barEnum = Bars.Study;
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

    public IEnumerator FadeOut (GameObject x)
    {
        Image y = x.GetComponent<Image>();
        visible = new Color(y.color.r, y.color.g, y.color.b, 1f);
        invisible = new Color(y.color.r, y.color.g, y.color.b, 0f);
        y.color = visible; //set visible
        fadeElapsedTime = 0f;
        while (fadeElapsedTime < fadeDuration)
        {
            fadeElapsedTime += Time.deltaTime;
            float percentageCompleted = fadeElapsedTime / fadeDuration;
            y.color = Color.Lerp(visible, invisible, percentageCompleted);
            yield return null;
        }
    }
    private void AddInputCoolDown() { Player.Instance.inputCooldown = inputCooldown; }
}
