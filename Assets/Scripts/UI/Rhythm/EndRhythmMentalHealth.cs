using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndRhythmMentalHealth : MonoBehaviour
{
    private float currentMentalHealth;

    TextMeshProUGUI text;

    void OnEnable()
    {
        currentMentalHealth = PlayerData.Instance.mentalHealth;
        float valueToAdd = EndRhythmScreen.Instance.GetComponent<ManagementModifier>().changeInMentalHealth / (EndRhythmScreen.Instance.successPercent / 100);
        text.text = "Mental Health: " + currentMentalHealth + " + " + valueToAdd;
    }
}
