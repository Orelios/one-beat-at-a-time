using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndRhythmMentalHealth : MonoBehaviour
{
    private float currentMentalHealth;
    private float valueToAdd;

    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        currentMentalHealth = PlayerData.Instance.mentalHealth;

        float min = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.mentalHealthMin;
        float max = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.mentalHealthMax;
        valueToAdd = min + ((max - min) * (EndRhythmScreen.Instance.successPercent / 100));

        //change PlayerData value
        PlayerData.Instance.AddMentalHealth(Mathf.Round(valueToAdd));

        text.text = "Mental Health: " + currentMentalHealth + " + " + Mathf.Round(valueToAdd) + " = " + PlayerData.Instance.mentalHealth;

        
    }
}
