using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeslotsRemaining : MonoBehaviour
{
    public Sprite[] timeslotImages;
    void OnEnable()
    {
        if (PlayerData.Instance.timeslot <= 0)
        {
            GetComponent<Image>().sprite = timeslotImages[0];
        }
        else if (PlayerData.Instance.timeslot == 1)
        {
            GetComponent<Image>().sprite = timeslotImages[1];
        }
        else if (PlayerData.Instance.timeslot == 2)
        {
            GetComponent<Image>().sprite = timeslotImages[2];
        }
        else if (PlayerData.Instance.timeslot == 3)
        {
            GetComponent<Image>().sprite = timeslotImages[3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
