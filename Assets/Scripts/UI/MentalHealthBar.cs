using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class MentalHealthBar : Singleton<MentalHealthBar>
{
    public GameObject bar;

    void Start()
    {
        UpdateBar();
    }

    void Update()
    {
        UpdateBar();
    }

    public void UpdateBar()
    {
        //image.fillAmount = PlayerData.Instance.productivity / PlayerData.Instance.maxProductivity;
        if (PlayerData.Instance.mentalHealth <= 10)
        {
            bar.transform.GetChild(0).gameObject.SetActive(true);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.mentalHealth <= 20)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(true);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.mentalHealth <= 30)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(true);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.mentalHealth <= 40)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(true);
            bar.transform.GetChild(4).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.mentalHealth <= 50)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(true);
        }
    }
}
