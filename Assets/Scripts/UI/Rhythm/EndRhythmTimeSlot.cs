using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRhythmTimeSlot : MonoBehaviour
{
    public GameObject timeSlot;
    void OnEnable()
    {
        timeSlot.transform.GetChild(0).gameObject.SetActive(true);
        timeSlot.transform.GetChild(1).gameObject.SetActive(true);
        timeSlot.transform.GetChild(2).gameObject.SetActive(true);

        timeSlot.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        timeSlot.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        timeSlot.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
}

