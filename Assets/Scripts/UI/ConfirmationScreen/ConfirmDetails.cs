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
        if (x.tag == "object")
        {
            confirmRef = x.GetComponent<RhythmStats>();
            text.text = "Mental Health " + PlusOrMinusMentalHealth() + " " + Mathf.Abs(confirmRef.stats.mentalHealthMax) +
                "\nProductivity " + PlusOrMinusProductivity() + " " + Mathf.Abs(confirmRef.stats.productivityMax) +
                "\nTime - " + Mathf.Abs(confirmRef.stats.timeChange);
        }
        else if (x.tag == "Teleport") //"overworld" door to home/school
        {
            if (PlayerData.Instance.timeslot > 0)
            {
                text.text = x.GetComponent<OverworldDoor>().overworldDetails +
                    "\nYou still have remaining Timeslots left";
            }
            if (PlayerData.Instance.timeslot <= 0)
            {
                text.text = x.GetComponent<OverworldDoor>().overworldDetails +
                    "\nNo more Timeslots remaining";
            }
            
        }
    }

    public string PlusOrMinusMentalHealth()
    {
        string plusOrMinus = "error";
        if (confirmRef.stats.mentalHealthMax > 0)
        {
            plusOrMinus = "+";
        }
        else if (confirmRef.stats.mentalHealthMax < 0)
        {
            plusOrMinus = "-";
        }
        else if (confirmRef.stats.mentalHealthMax == 0)
        {
            plusOrMinus = "";
        }
        return plusOrMinus;
    }

    public string PlusOrMinusProductivity()
    {
        string plusOrMinus = "error";
        if (confirmRef.stats.productivityMax > 0)
        {
            plusOrMinus = "+";
        }
        else if (confirmRef.stats.productivityMax < 0)
        {
            plusOrMinus = "-";
        }
        else if (confirmRef.stats.productivityMax == 0)
        {
            plusOrMinus = "";
        }
        return plusOrMinus;
    }
}
