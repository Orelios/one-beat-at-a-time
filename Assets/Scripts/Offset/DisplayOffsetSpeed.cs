using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayOffsetSpeed : Singleton<DisplayOffsetSpeed>
{
    TextMeshProUGUI text;
    public float offsetSpeedValue;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + offsetSpeedValue;
    }

    public void RoundOffsetTo1Decimal()
    {
        offsetSpeedValue = Mathf.Round(offsetSpeedValue * 10.0f) * 0.1f;
    }

    public void UpdateValue()
    {
        RoundOffsetTo1Decimal();
        text.text = "" + offsetSpeedValue;
    }

    public void SaveOffset()
    {
        RoundOffsetTo1Decimal();
        PlayerData.Instance.offsetNoteSpeed = offsetSpeedValue;
    }

    public void IncreaseSmall()
    {
        offsetSpeedValue += 0.1f;
        UpdateValue();
    }

    public void IncreaseBig()
    {
        offsetSpeedValue += 1.0f;
        UpdateValue();
    }

    public void DecreaseSmall()
    {
        offsetSpeedValue -= 0.1f;
        UpdateValue();
    }

    public void DecreaseBig()
    {
        offsetSpeedValue -= 1.0f;
        UpdateValue();
    }
}
