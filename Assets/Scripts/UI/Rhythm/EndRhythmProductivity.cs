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

        float min = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.productivityMin;
        float max = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.productivityMax;
        valueToAdd = min + ((max - min) * (EndRhythmScreen.Instance.successPercent / 100));

        //change PlayerData value
        PlayerData.Instance.AddProductivity(Mathf.Round(valueToAdd));

        text.text = "Productivity: " + currentProductivity + " + " + Mathf.Round(valueToAdd) + " = " + PlayerData.Instance.productivity;

        
    }
}
