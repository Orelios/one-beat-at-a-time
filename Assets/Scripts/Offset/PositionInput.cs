using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionInput : Singleton<PositionInput>
{
    public float offsetPosValue, offsetPosDisplay, multiplier = 0.1f; // offsetPosDisplay is 1/10th of actual value
    //public string inputValue;
    public InputField inputField;

    private void OnEnable()
    {
        offsetPosValue = PlayerPrefs.GetFloat("offsetPos");
        //inputField = GetComponent<TMP_InputField>();
        DisplayConverted();
    }

    public void DisplayConverted()
    {
        offsetPosDisplay = (offsetPosValue * multiplier);
        inputField.text = offsetPosDisplay.ToString();
    }

    public void SaveOffset()
    {
        //offsetPosValue = float.Parse(inputField.text);
        PlayerPrefs.SetFloat("offsetPos", offsetPosValue);
    }

    public void ApplyOffset()
    {
        offsetPosDisplay = float.Parse(inputField.text);
        offsetPosValue = (offsetPosDisplay / multiplier);
    }

    public void IncreaseBig()
    {
        offsetPosValue += 10f;
        DisplayConverted();
    }

    public void IncreaseSmall()
    {
        offsetPosValue += 1f;
        DisplayConverted();
    }

    public void DecreaseBig()
    {
        offsetPosValue -= 10f;
        DisplayConverted();
    }

    public void DecreaseSmall()
    {
        offsetPosValue -= 1f;
        DisplayConverted();
    }

    /*
    public void ChangePosOffset(string newlyTyped)
    {
        inputValue = newlyTyped;
        float input = float.Parse(inputValue);
        offsetPosValue += input;
    }
    */
}
