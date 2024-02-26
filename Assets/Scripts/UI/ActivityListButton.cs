using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityListButton : MonoBehaviour
{
    public GameObject activityList;

    public void ToggleActivityList()
    {
        if (activityList.activeInHierarchy)
        {
            activityList.SetActive(false);
        }
        else
        {
            activityList.SetActive(true);
        }
    }
}
