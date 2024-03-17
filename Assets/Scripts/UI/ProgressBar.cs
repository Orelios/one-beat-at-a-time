using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image image;
    [SerializeField] private float maxProgress = 100.0f;
    [SerializeField] private float progress;
    [SerializeField] private float progressDecPerSec = 1.0f;
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
        if (progress <= 0)
        {
            progress = 0.0f;
        }
        else if (progress >= 100)
        {
            progress = 100.0f;
            //EndRhythmScreen.Instance.StopGame();
        }
        else
        {
            progress -= Time.deltaTime * progressDecPerSec;
        }
        image.fillAmount = progress / maxProgress;
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
}
