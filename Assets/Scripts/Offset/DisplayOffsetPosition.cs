using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayOffsetPosition : Singleton<DisplayOffsetPosition>
{
    TextMeshProUGUI text;
    public float offsetPosValue;

    private void OnEnable()
    {
        offsetPosValue = PlayerPrefs.GetFloat("offsetPos");
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + offsetPosValue;
    }

    public void RoundOffsetTo1Decimal()
    {
        offsetPosValue = Mathf.Round(offsetPosValue * 10.0f) * 0.1f;
    }

    public void UpdateValue()
    {
        RoundOffsetTo1Decimal();
        text.text = "" + offsetPosValue;
    }

    public void SaveOffset()
    {
        RoundOffsetTo1Decimal();
        //PlayerData.Instance.offsetPos = offsetPosValue;
        PlayerPrefs.SetFloat("offsetPos", offsetPosValue);
    }

    public void IncreaseSmall()
    {
        offsetPosValue += 0.1f;
        UpdateValue();
    }

    public void IncreaseBig()
    {
        offsetPosValue += 1.0f;
        UpdateValue();
    }

    public void DecreaseSmall()
    {
        offsetPosValue -= 0.1f;
        UpdateValue();
    }

    public void DecreaseBig()
    {
        offsetPosValue -= 1.0f;
        UpdateValue();
    }
}
