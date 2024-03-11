using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityListButton : MonoBehaviour
{
    public GameObject activityList;
    public List<GameObject> indicators;

    private void Start()
    {
        indicators.AddRange(GameObject.FindGameObjectsWithTag("ActivityIndicator"));
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
            DisableIndicators();
        }
        else
        {
            activityList.SetActive(true);
            EnableIndicators();
        }
    }

    public void DisableIndicators()
    {
        foreach (GameObject indicator in indicators)
        {
            indicator.SetActive(false);
        }
    }

    public void EnableIndicators()
    {
        foreach (GameObject indicator in indicators)
        {
            indicator.SetActive(true);
        }
    }
}