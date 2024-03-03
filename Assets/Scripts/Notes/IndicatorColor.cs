using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColor : Singleton<IndicatorColor>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeIndicatorColor()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            //IndicatorColor.Instance.//color = early;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            //IndicatorColor.Instance.//color = perfect;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
            //IndicatorColor.Instance.//color = late;
        }
    }
}
