using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndOfDayScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject startMental, startProductivity, endMental, endProductivity;
    [SerializeField] private Sprite[] mentalSprites;
    [SerializeField] private Sprite[] productivitySprites;
    public string prod, prod1, prod2, mental, mental1, mental2;

    void OnEnable()
    {
        //text = GetComponent<TextMeshProUGUI>();

        GetProd();
        GetMental();

        text.text = "By the end of the day, Aria thinks she" + prod
            + "\nAs her body hits the bed, she" + mental;
            //made some progress today.\r\nAs her body hits the bed, she feels tired and promptly falls asleep.";

        GetStartMental();
        GetStartProductivity();
        GetEndMental();
        GetEndProductivity();
    }

    private void GetProd()
    {
        if (PlayerData.Instance.productivity <= 30)
        {
            mental = mental1;
        }
        else if (PlayerData.Instance.productivity <= 60)
        {
            mental = mental2;
        }
    }

    private void GetMental()
    {
        if (PlayerData.Instance.mentalHealth <= 20)
        {
            prod = prod1;
        }
        else if (PlayerData.Instance.mentalHealth <= 50)
        {
            prod = prod2;
        }
    }

    private void GetStartMental()
    {
        if (PlayerData.Instance.startMentalHealth >= 41)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[4];
        }
        else if (PlayerData.Instance.startMentalHealth >= 31)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[3];
        }
        else if (PlayerData.Instance.startMentalHealth >= 21)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[2];
        }
        else if (PlayerData.Instance.startMentalHealth >= 11)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[1];
        }
        else if (PlayerData.Instance.startMentalHealth <= 10)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[0];
        }
    }

    private void GetStartProductivity()
    {
        if (PlayerData.Instance.startProductivity >= 51)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[6];
        }
        else if (PlayerData.Instance.startProductivity >= 41)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[5];
        }
        else if (PlayerData.Instance.startProductivity >= 31)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[4];
        }
        else if (PlayerData.Instance.startProductivity >= 21)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[3];
        }
        else if (PlayerData.Instance.startProductivity >= 11)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[2];
        }
        else if (PlayerData.Instance.startProductivity >= 1)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[1];
        }
        else if (PlayerData.Instance.startProductivity == 0)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[0];
        }
    }

    private void GetEndMental()
    {
        if (PlayerData.Instance.mentalHealth >= 41)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[4];
        }
        else if (PlayerData.Instance.mentalHealth >= 31)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[3];
        }
        else if (PlayerData.Instance.mentalHealth >= 21)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[2];
        }
        else if (PlayerData.Instance.mentalHealth >= 11)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[1];
        }
        else if (PlayerData.Instance.mentalHealth <= 10)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[0];
        }
    }

    private void GetEndProductivity()
    {
        if (PlayerData.Instance.productivity >= 51)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[6];
        }
        else if (PlayerData.Instance.productivity >= 41)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[5];
        }
        else if (PlayerData.Instance.productivity >= 31)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[4];
        }
        else if (PlayerData.Instance.productivity >= 21)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[3];
        }
        else if (PlayerData.Instance.productivity >= 11)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[2];
        }
        else if (PlayerData.Instance.productivity >= 1)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[1];
        }
        else if (PlayerData.Instance.productivity == 0)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[0];
        }
    }
}
