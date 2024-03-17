using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarManipulator : MonoBehaviour
{
    public ProgressBar progressBar;
    //[SerializeField] private bool perArrow = false;
    //[SerializeField] private bool perPattern = false;

    public void AddSmall()
    {
        progressBar.AddProgressSmall();
    }

    public void AddMedium()
    {
        progressBar.AddProgressMedium();
    }

    public void AddLarge()
    {
        progressBar.AddProgressLarge();
    }

    public void SubtractSmall()
    {
        progressBar.SubtractProgressSmall();
    }

    public void SubtractMedium()
    {
        progressBar.SubtractProgressMedium();
    }

    public void SubtractLarge()
    {
        progressBar.SubtractProgressLarge();
    }
}
