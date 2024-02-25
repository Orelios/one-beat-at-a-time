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
        GetComponent<TooltipTrigger>().content = "Mental Health + " + _statsRef.stats.mentalHealthChange +
            "\nProductivity + " + _statsRef.stats.productivityChange +
            "\nTime " + _statsRef.stats.timeChange;
    }
}
