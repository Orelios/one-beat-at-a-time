using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ComboSystem : Singleton<ComboSystem>
{
    public TMP_Text comboScoreText;
    public int AddComboScore = 0; 
    public int comboScore = 0;
    public int comboScoreLimit = 0; 
   
    private void Start()
    {
        comboScoreText.text = "Combos: " + comboScore + "X"; 
    }
    public void AddToCombo()
    {
        if(comboScore != comboScoreLimit) { comboScore += AddComboScore; }
    }

    public void ResetCombo()
    {
        comboScore = 0; 
    }

    public void UpdateScore()
    {
        if(comboScore != comboScoreLimit) { comboScoreText.text = "Combos: " + comboScore + "X"; }
        else { comboScoreText.text = "Max Combo: " + comboScore + "X"; }
    }
}
