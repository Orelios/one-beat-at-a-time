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
        valueToAdd = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.productivityChange / (EndRhythmScreen.Instance.successPercent / 100);
        //change PlayerData value
        PlayerData.Instance.AddProductivity(valueToAdd);

        text.text = "Productivity: " + currentProductivity + " + " + valueToAdd + " = " + PlayerData.Instance.productivity;

        
    }
}
