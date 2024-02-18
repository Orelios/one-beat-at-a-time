using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndRhythmProductivity : MonoBehaviour
{
    private float currentProductivity;
    private float valueToAdd;

    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        currentProductivity = PlayerData.Instance.productivity;
        valueToAdd = EndRhythmScreen.Instance.GetComponent<ManagementModifier>().changeInProductivity / (EndRhythmScreen.Instance.successPercent / 100);
        text.text = "Productivity: " + currentProductivity + " + " + valueToAdd + " = " + (currentProductivity + valueToAdd);

        //change PlayerData value
        PlayerData.Instance.AddProductivity(valueToAdd);
    }
}
