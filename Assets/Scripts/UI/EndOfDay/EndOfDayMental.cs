using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayMental : MonoBehaviour
{
    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Mental Health: " + PlayerData.Instance.mentalHealth;

    }
}
