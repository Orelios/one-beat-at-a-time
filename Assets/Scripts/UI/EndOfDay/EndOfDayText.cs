using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayText : MonoBehaviour
{
    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "End of Day " + PlayerData.Instance.day;

    }
}
