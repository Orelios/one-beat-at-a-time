using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipRefMofifier : MonoBehaviour
{
    public ManagementModifier modifier;
    void Start()
    {
        GetComponent<TooltipTrigger>().header = gameObject.name;
        GetComponent<TooltipTrigger>().content = "Mental Health + " + modifier.changeInMentalHealth + 
            "\nProductivity + " + modifier.changeInProductivity + 
            "\nTime " + modifier.changeInTimeRemaining;
    }
}
