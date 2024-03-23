using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllotedTime : MonoBehaviour
{
    public GameObject allotedTime;
    private void Awake()
    {
        allotedTime.transform.GetChild(0).gameObject.SetActive(false);
        allotedTime.transform.GetChild(1).gameObject.SetActive(false);
        allotedTime.transform.GetChild(2).gameObject.SetActive(false);
    }

    void Update()
    {
        if(PlayerData.Instance.timeslot == 1) 
        {
            allotedTime.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(PlayerData.Instance.timeslot == 2) 
        {
            allotedTime.transform.GetChild(0).gameObject.SetActive(true);
            allotedTime.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (PlayerData.Instance.timeslot == 3) 
        {
            allotedTime.transform.GetChild(0).gameObject.SetActive(true);
            allotedTime.transform.GetChild(1).gameObject.SetActive(true);
            allotedTime.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            allotedTime.transform.GetChild(0).gameObject.SetActive(false);
            allotedTime.transform.GetChild(1).gameObject.SetActive(false);
            allotedTime.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
