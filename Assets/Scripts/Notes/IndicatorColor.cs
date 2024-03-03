using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorColor : Singleton<IndicatorColor>
{
    public float returnDelay;
    public void ChangeIndicatorColor()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        StartCoroutine(RetrunToOriginal());
    }

    private IEnumerator RetrunToOriginal()
    {
        yield return new WaitForSeconds(returnDelay);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
