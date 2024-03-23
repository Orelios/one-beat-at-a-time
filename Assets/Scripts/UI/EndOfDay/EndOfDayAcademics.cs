using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayAcademics : MonoBehaviour
{
    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Academics: " + PlayerData.Instance.productivity;

    }
}
