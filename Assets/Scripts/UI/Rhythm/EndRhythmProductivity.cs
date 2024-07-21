using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndRhythmProductivity : MonoBehaviour
{
    private float currentProductivity;
    private float valueToAdd;

    void OnEnable()
    {
        currentProductivity = PlayerData.Instance.productivity;

        float min = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.productivityMin;
        float max = EndRhythmScreen.Instance.GetComponent<RhythmStats>().stats.productivityMax;
        valueToAdd = min + ((max - min) * (EndRhythmScreen.Instance.successPercent / 100));

        //change PlayerData value
        Mathf.Round(valueToAdd);
        Debug.Log(valueToAdd); 
        PlayerData.Instance.AddProductivity(valueToAdd);
        ChangeIcons();
        
    }
    private void ChangeIcons()
    {
        if(valueToAdd <= 0)
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= 2)
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= 4)
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else if (valueToAdd <= 6)
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
