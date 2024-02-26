using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConfirmDetails : Singleton<ConfirmDetails>
{
    TextMeshProUGUI text;
    public RhythmStats confirmRef;

    public void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetAsReference(GameObject x)
    {
        confirmRef = x.GetComponent<RhythmStats>();
        text.text = "Mental Health " + PlusOrMinusMentalHealth() + " " + Mathf.Abs(confirmRef.stats.mentalHealthChange) +
            "\nProductivity " + PlusOrMinusProductivity() + " " + Mathf.Abs(confirmRef.stats.productivityChange) +
            "\nTime - " + Mathf.Abs(confirmRef.stats.timeChange);
    }

    public string PlusOrMinusMentalHealth()
    {
        string plusOrMinus = "error";
        if (confirmRef.stats.mentalHealthChange > 0)
        {
            plusOrMinus = "+";
        }
        else if (confirmRef.stats.mentalHealthChange < 0)
        {
            plusOrMinus = "-";
        }
        else if (confirmRef.stats.mentalHealthChange == 0)
        {
            plusOrMinus = "";
        }
        return plusOrMinus;
    }

    public string PlusOrMinusProductivity()
    {
        string plusOrMinus = "error";
        if (confirmRef.stats.productivityChange > 0)
        {
            plusOrMinus = "+";
        }
        else if (confirmRef.stats.productivityChange < 0)
        {
            plusOrMinus = "-";
        }
        else if (confirmRef.stats.productivityChange == 0)
        {
            plusOrMinus = "";
        }
        return plusOrMinus;
    }
}
