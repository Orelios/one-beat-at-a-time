using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusBar : Singleton<FocusBar>
{
    public Image currentFocusBarIndicator; 
    Image image;
    [SerializeField] private float maxProgress = 100.0f;
    [SerializeField] private float progress;
    public float progressDecPerSec = 1.0f;
    [SerializeField] private float small;
    [SerializeField] private float medium;
    [SerializeField] private float large;

    void Start()
    {
        image = GetComponent<Image>();
        image.type = Image.Type.Filled;
        image.fillAmount = progress / maxProgress;
    }

    // Update is called once per frame
    void Update()
    {
        progress -= Time.deltaTime * progressDecPerSec;
        if (progress <= 0)
        {
            progress = 0.0f;
        }
        if (progress >= 100)
        {
            progress = 100.0f;
            //EndRhythmScreen.Instance.StopGame();
        }
        image.fillAmount = progress / maxProgress;
        FocusBarPercent();
    }
    public void FocusBarPercent()
    {
        if(GetComponent<Image>().fillAmount <= 0.33) { ProgressBar.Instance.progressDecPerSec = 2f; }
        else if (GetComponent<Image>().fillAmount <= 0.66) { ProgressBar.Instance.progressDecPerSec = 1.5f; }
        else if (GetComponent<Image>().fillAmount <= 1) { ProgressBar.Instance.progressDecPerSec = 1f; }
    }
    public void AddProgressSmall()
    {
        progress += small;
    }

    public void AddProgressMedium()
    {
        progress += medium;
    }

    public void AddProgressLarge()
    {
        progress += large;
    }

    public void SubtractProgressSmall()
    {
        progress -= small;
    }

    public void SubtractProgressMedium()
    {
        progress -= medium;
    }

    public void SubtractProgressLarge()
    {
        progress -= large;
    }

    public float GetProgress()
    {
        return progress;
    }
}