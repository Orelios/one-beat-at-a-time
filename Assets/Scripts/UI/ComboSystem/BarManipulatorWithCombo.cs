using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManipulatorWithCombo : Singleton<BarManipulatorWithCombo>
{
    public ProgressBar progressBar;
    public NoteDetection detector;
    public float progressDecPerSecFocusBar;
    private void Start()
    {
    }
    private void Update()
    {
    }
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

    public void PlayerMiss()
    {
        progressBar.SubtractProgressMedium();
    }

    public void AddCombo()
    {
        progressBar.AddComboScore(); 
    }
}
