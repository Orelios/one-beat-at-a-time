using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffsetPerfectCounterImage : MonoBehaviour
{
    public int perfects; 
    public void PerfectTracker()
    {
        perfects++;
        if(perfects == 1) { gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.green; }
        else if (perfects == 2) { gameObject.transform.GetChild(1).GetComponent<Image>().color = Color.green; }
        else if (perfects == 3) { gameObject.transform.GetChild(2).GetComponent<Image>().color = Color.green; }
    }

    public void ResetProgress() 
    {
        for (int x = 0; x < 3; x++) { gameObject.transform.GetChild(x).GetComponent<Image>().color = Color.white; }
        perfects = 0; 
    }
}
