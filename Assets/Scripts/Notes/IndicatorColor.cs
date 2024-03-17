using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColor : Singleton<IndicatorColor>
{
    public float returnDelay;

    private void OnEnable()
    {
        
    }

    public void ChangeIndicatorColor()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<ProgressBarManipulator>().AddSmall();
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            GetComponent<ProgressBarManipulator>().AddMedium();
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            GetComponent<ProgressBarManipulator>().AddSmall();
        }
        StartCoroutine(RetrunToOriginal());
    }

    private IEnumerator RetrunToOriginal()
    {
        yield return new WaitForSeconds(returnDelay);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
