using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayOffset : MonoBehaviour
{
    TextMeshProUGUI text;
    public float offsetValue;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + offsetValue;
    }

    public void RoundOffsetTo1Decimal()
    {
        offsetValue = Mathf.Round(offsetValue * 10.0f) * 0.1f;
    }

    public void UpdateValue()
    {
        RoundOffsetTo1Decimal();
        text.text = "" + offsetValue;
    }

    public void SaveOffset()
    {
        RoundOffsetTo1Decimal();
        PlayerData.Instance.offset = offsetValue;
    }

    public void IncreaseSmall()
    {
        offsetValue += 0.1f;
        UpdateValue();
    }

    public void IncreaseBig()
    {
        offsetValue += 1.0f;
        UpdateValue();
    }

    public void DecreaseSmall()
    {
        offsetValue -= 0.1f;
        UpdateValue();
    }

    public void DecreaseBig()
    {
        offsetValue -= 1.0f;
        UpdateValue();
    }
}
