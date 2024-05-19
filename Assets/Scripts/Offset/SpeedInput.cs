using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedInput : Singleton<SpeedInput>
{
    public float offsetSpeedValue;
    public InputField inputField;

    private void OnEnable()
    {
        offsetSpeedValue = PlayerPrefs.GetFloat("offsetNoteSpeed");
        inputField.text = offsetSpeedValue.ToString();
    }

    public void SaveOffset()
    {
        //offsetSpeedValue = float.Parse(inputField.text);
        PlayerPrefs.SetFloat("offsetNoteSpeed", offsetSpeedValue);
    }

    public void ApplyOffset()
    {
        offsetSpeedValue = float.Parse(inputField.text);
    }
}
