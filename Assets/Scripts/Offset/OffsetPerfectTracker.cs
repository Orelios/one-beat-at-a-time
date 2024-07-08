using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPerfectTracker : MonoBehaviour
{
    public int perfectCount;
    public bool isPerfect3 = false;

    private void OnEnable()
    {
        isPerfect3 = false;
    }

    public void IncrementPerfectCount()
    {
        perfectCount += 1;
        if (perfectCount == 3)
        {
            isPerfect3 = true;
        }
    }

    public void ResetPerfectCount() { perfectCount = 0; }
}
