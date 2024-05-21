using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPosition : MonoBehaviour
{
    TextMeshProUGUI text;

    void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "" + this.transform.parent.localPosition;

    }

    private void Update()
    {
        text.text = "" + this.transform.parent.localPosition;
    }
}
