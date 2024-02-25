using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipReference : MonoBehaviour
{
    //public GameObject door;
    public RhythmStats _statsRef;

    void Start()
    {
        //_statsRef = door.GetComponent<StatsScriptableObjects>();
        GetComponent<TooltipTrigger>().header = gameObject.name;
        GetComponent<TooltipTrigger>().content = "Mental Health" + ShowMentalHealthChange() +
            "\nProductivity" + ShowProductivityChange() +
            "\nTime" + ShowTimeChange();
    }

    /*
    public string PlusOrMinusMentalHealth()
    {
        string plusOrMinus = "error";
        if (_statsRef.stats.mentalHealthChange > 0)
        {
            plusOrMinus = "+";
        }
        else if (_statsRef.stats.mentalHealthChange < 0)
        {
            plusOrMinus = "-";
        }
        else if (_statsRef.stats.mentalHealthChange == 0)
        {
            plusOrMinus = "";
        }
        return plusOrMinus;
    }

    public string PlusOrMinusProductivity()
    {
        string plusOrMinus = "error";
        if (_statsRef.stats.productivityChange > 0)
        {
            plusOrMinus = "+";
        }
        else if (_statsRef.stats.productivityChange < 0)
        {
            plusOrMinus = "-";
        }
        else if (_statsRef.stats.productivityChange == 0)
        {
            plusOrMinus = "";
        }
        return plusOrMinus;
    }
    */

    public string ShowMentalHealthChange()
    {
        string mentalSymbol = " error";
        if (_statsRef.stats.mentalHealthChange > 0)
        {
            if (_statsRef.stats.mentalHealthChange <= TooltipStatRange.Instance.mental1)
            {
                mentalSymbol = "+";
            }
            else if (_statsRef.stats.mentalHealthChange <= TooltipStatRange.Instance.mental2)
            {
                mentalSymbol = "++";
            }
            else if (_statsRef.stats.mentalHealthChange <= TooltipStatRange.Instance.mental3)
            {
                mentalSymbol = "+++";
            }
            else if (_statsRef.stats.mentalHealthChange > TooltipStatRange.Instance.mental3)
            {
                mentalSymbol = "++++";
            }
        }

        else if (_statsRef.stats.mentalHealthChange < 0)
        {
            if (_statsRef.stats.mentalHealthChange >= TooltipStatRange.Instance.mentalNeg1)
            {
                mentalSymbol = "-";
            }
            else if (_statsRef.stats.mentalHealthChange >= TooltipStatRange.Instance.mentalNeg2)
            {
                mentalSymbol = "--";
            }
            else if (_statsRef.stats.mentalHealthChange >= TooltipStatRange.Instance.mentalNeg3)
            {
                mentalSymbol = "---";
            }
            else if (_statsRef.stats.mentalHealthChange < TooltipStatRange.Instance.mental3)
            {
                mentalSymbol = "----";
            }
        }

        else if (_statsRef.stats.mentalHealthChange == 0)
        {
            mentalSymbol = " no change";
        }

        return mentalSymbol;
    }

    public string ShowProductivityChange()
    {
        string productivitySymbol = " error";
        if (_statsRef.stats.productivityChange > 0)
        {
            if (_statsRef.stats.productivityChange <= TooltipStatRange.Instance.productivity1)
            {
                productivitySymbol = "+";
            }
            else if (_statsRef.stats.productivityChange <= TooltipStatRange.Instance.productivity2)
            {
                productivitySymbol = "++";
            }
            else if (_statsRef.stats.productivityChange <= TooltipStatRange.Instance.productivity3)
            {
                productivitySymbol = "+++";
            }
            else if (_statsRef.stats.productivityChange > TooltipStatRange.Instance.productivity3)
            {
                productivitySymbol = "++++";
            }
        }

        else if (_statsRef.stats.productivityChange < 0)
        {
            productivitySymbol = " wala dapat negative productivity";
        }

        else if (_statsRef.stats.productivityChange == 0)
        {
            productivitySymbol = " no change";
        }

        return productivitySymbol;
    }

    public string ShowTimeChange()
    {
        string timeSymbol = " error";
        if (_statsRef.stats.timeChange < 0)
        {
            if (_statsRef.stats.timeChange >= TooltipStatRange.Instance.time1)
            {
                timeSymbol = "-";
            }
            else if (_statsRef.stats.timeChange >= TooltipStatRange.Instance.time2)
            {
                timeSymbol = "--";
            }
            else if (_statsRef.stats.timeChange >= TooltipStatRange.Instance.time3)
            {
                timeSymbol = "---";
            }
            else if (_statsRef.stats.timeChange < TooltipStatRange.Instance.time3)
            {
                timeSymbol = "----";
            }
        }

        else if (_statsRef.stats.timeChange > 0)
        {
            timeSymbol = " wala dapat positive time change";
        }

        else if (_statsRef.stats.timeChange == 0)
        {
            timeSymbol = " no change";
        }

        return timeSymbol;
    }
}
