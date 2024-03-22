using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    public int timingValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("it hit " + timingValue); 
        if (other.gameObject.tag == "TimingEarly")
        {
            timingValue = 1;
        }
        else if (other.gameObject.tag == "TimingPerfect")
        {
            timingValue = 2;
        }
        else if (other.gameObject.tag == "TimingLate")
        {
            timingValue = 3;
        }
        else if(other.gameObject.tag == "Miss")
        {
            timingValue = 4;
            if (NoteDetection.Instance.noteInDetector.GetComponent<NoteTiming>().timingValue == 4)
            {
                BarManipulator.Instance.SubtractMedium(BarManipulator.Instance._changeBar);
            }
        }
        //Debug.Log("it hit " + timingValue);
    }
}
