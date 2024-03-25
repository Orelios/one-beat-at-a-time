using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreenText : Singleton<EndingScreenText>
{
    private void OnEnable()
    {
        if(FocusBar.Instance.GetComponent<Image>().fillAmount >= 1) { CatGameOver(); }
        else { NormalGameOver(); }
    }
    public void NormalGameOver()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void CatGameOver()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}

