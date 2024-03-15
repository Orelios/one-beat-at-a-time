using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityListButton : MonoBehaviour
{
    public GameObject activityList;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleActivityList();
        }
    }

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