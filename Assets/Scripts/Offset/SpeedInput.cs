using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedInput : Singleton<SpeedInput>
{
    public float offsetSpeedValue, offsetSpeedDisplay, multiplier = 0.1f;
    public InputField inputField;

    private void OnEnable()
    {
        offsetSpeedValue = PlayerPrefs.GetFloat("offsetNoteSpeed");
        inputField.text = offsetSpeedValue.ToString();
    }

    public void DisplayConverted()
    {
        offsetSpeedDisplay = (offsetSpeedValue * multiplier);
        inputField.text = offsetSpeedDisplay.ToString();
    }

    public void SaveOffset()
    {
        //offsetSpeedValue = float.Parse(inputField.text);
        PlayerPrefs.SetFloat("offsetNoteSpeed", offsetSpeedValue);
    }

    public void ApplyOffset()
    {
        offsetSpeedDisplay = float.Parse(inputField.text);
        offsetSpeedValue = (offsetSpeedDisplay / multiplier);
    }

    public void IncreaseBig()
    {
        offsetSpeedValue += 10f;
        DisplayConverted();
    }

    public void IncreaseSmall()
    {
        offsetSpeedValue += 1f;
        DisplayConverted();
    }

    public void DecreaseBig()
    {
        offsetSpeedValue -= 10f;
        DisplayConverted();
    }

    public void DecreaseSmall()
    {
        offsetSpeedValue -= 1f;
        DisplayConverted();
    }
}
