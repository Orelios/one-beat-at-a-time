using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    public int timingValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
    }
}
