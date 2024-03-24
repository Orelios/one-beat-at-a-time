using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllotedTime : MonoBehaviour
{
    public GameObject allotedTime;
    private void Awake()
    {
        allotedTime.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        allotedTime.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        allotedTime.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }

    void Update()
    {
        if(PlayerData.Instance.timeslot == 1) 
        {
            allotedTime.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            allotedTime.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            allotedTime.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if(PlayerData.Instance.timeslot == 2) 
        {
            allotedTime.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            allotedTime.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            allotedTime.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (PlayerData.Instance.timeslot == 3) 
        {
            allotedTime.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            allotedTime.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            allotedTime.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            allotedTime.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            allotedTime.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            allotedTime.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
    }
}
