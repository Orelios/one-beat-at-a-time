using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPosition : MonoBehaviour
{
    TextMeshProUGUI text;
    public float multiplier = 1.0f;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + this.transform.parent.localPosition * multiplier;

    }

    private void Update()
    {
        text.text = "" + this.transform.parent.localPosition * multiplier;
    }
}
