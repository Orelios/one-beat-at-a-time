using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class ProductivityBar : Singleton<ProductivityBar>
{
    public GameObject bar;

    void Start()
    {
        UpdateBar();
    }

    void Update()
    {

    }

    public void UpdateBar()
    {
        //image.fillAmount = PlayerData.Instance.productivity / PlayerData.Instance.maxProductivity;
        if (PlayerData.Instance.productivity == 2) 
        {
            bar.transform.GetChild(0).gameObject.SetActive(true);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
            bar.transform.GetChild(5).gameObject.SetActive(false);
            bar.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.productivity <= 4)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(true);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
            bar.transform.GetChild(5).gameObject.SetActive(false);
            bar.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if(PlayerData.Instance.productivity <= 6)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(true);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
            bar.transform.GetChild(5).gameObject.SetActive(false);
            bar.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.productivity <= 8)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(true);
            bar.transform.GetChild(4).gameObject.SetActive(false);
            bar.transform.GetChild(5).gameObject.SetActive(false);
            bar.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.productivity <= 10)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(true);
            bar.transform.GetChild(5).gameObject.SetActive(false);
            bar.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.productivity <= 11)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
            bar.transform.GetChild(5).gameObject.SetActive(true);
            bar.transform.GetChild(6).gameObject.SetActive(false);
        }
        else if (PlayerData.Instance.productivity <= 12)
        {
            bar.transform.GetChild(0).gameObject.SetActive(false);
            bar.transform.GetChild(1).gameObject.SetActive(false);
            bar.transform.GetChild(2).gameObject.SetActive(false);
            bar.transform.GetChild(3).gameObject.SetActive(false);
            bar.transform.GetChild(4).gameObject.SetActive(false);
            bar.transform.GetChild(5).gameObject.SetActive(false);
            bar.transform.GetChild(6).gameObject.SetActive(true);
        }
    }
}
