using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorAboveImage : Singleton<IndicatorAboveImage>
{
    public Sprite[] aboveImageIndicator; 
    public float returnDelay;
    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = aboveImageIndicator[3];
    }
    public void ChangeAboveIndicatorImage()
    {
        if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 1)
        {
            GetComponent<SpriteRenderer>().sprite = aboveImageIndicator[0]; 
            //GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 2)
        {
            GetComponent<SpriteRenderer>().sprite = aboveImageIndicator[1];
            //GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 3)
        {
            GetComponent<SpriteRenderer>().sprite = aboveImageIndicator[2];
            //GetComponent<SpriteRenderer>().color = Color.blue;
        }
        StartCoroutine(RetrunToOriginal());
    }

    private IEnumerator RetrunToOriginal()
    {
        yield return new WaitForSeconds(returnDelay);
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().sprite = aboveImageIndicator[3];
    }

    public void MissChangeAboveIndicatorImage()
    {
        GetComponent<SpriteRenderer>().sprite = aboveImageIndicator[3];
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
