using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionInput : MonoBehaviour
{
    public float offsetPosValue;
    //public string inputValue;
    public InputField inputField;

    private void OnEnable()
    {
        offsetPosValue = PlayerPrefs.GetFloat("offsetPos");
        //inputField = GetComponent<TMP_InputField>();
        inputField.text = offsetPosValue.ToString();
    }

    public void SaveOffset()
    {
        //offsetPosValue = float.Parse(inputField.text);
        PlayerPrefs.SetFloat("offsetPos", offsetPosValue);
    }

    public void ApplyOffset()
    {
        offsetPosValue = float.Parse(inputField.text);
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
