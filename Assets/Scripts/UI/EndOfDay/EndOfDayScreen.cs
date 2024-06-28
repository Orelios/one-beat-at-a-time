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

    void Update()
    {
        //text = GetComponent<TextMeshProUGUI>();

        GetProd();
        GetMental();

        text.text = "By the end of the day, Aria thinks she" + prod
            + "\n\nAs her body hits the bed, she" + mental;
            //made some progress today.\r\nAs her body hits the bed, she feels tired and promptly falls asleep.";

        GetStartMental();
        GetStartProductivity();
        GetEndMental();
        GetEndProductivity();
    }

    private void GetProd()
    {
        if (PlayerData.Instance.productivity <= 6)
        {
            prod = prod1;
        }
        else if (PlayerData.Instance.productivity <= 12)
        {
            prod = prod2;
        }
    }

    private void GetMental()
    {
        if (PlayerData.Instance.mentalHealth <= 5)
        {
            mental = mental1;
        }
        else if (PlayerData.Instance.mentalHealth <= 10)
        {
            mental = mental2;
        }
    }

    private void GetStartMental()
    {
        if (PlayerData.Instance.startMentalHealth >= 9)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[4];
        }
        else if (PlayerData.Instance.startMentalHealth >= 7)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[3];
        }
        else if (PlayerData.Instance.startMentalHealth >= 5)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[2];
        }
        else if (PlayerData.Instance.startMentalHealth >= 3)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[1];
        }
        else if (PlayerData.Instance.startMentalHealth <= 2)
        {
            startMental.GetComponent<Image>().sprite = mentalSprites[0];
        }
    }

    private void GetStartProductivity()
    {
        if (PlayerData.Instance.startProductivity >= 11)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[6];
        }
        else if (PlayerData.Instance.startProductivity >= 9)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[5];
        }
        else if (PlayerData.Instance.startProductivity >= 7)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[4];
        }
        else if (PlayerData.Instance.startProductivity >= 5)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[3];
        }
        else if (PlayerData.Instance.startProductivity >= 3)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[2];
        }
        else if (PlayerData.Instance.startProductivity >= 1)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[1];
        }
        else if (PlayerData.Instance.startProductivity <= 0)
        {
            startProductivity.GetComponent<Image>().sprite = productivitySprites[0];
        }
    }

    private void GetEndMental()
    {
        if (PlayerData.Instance.mentalHealth >= 9)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[4];
        }
        else if (PlayerData.Instance.mentalHealth >= 7)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[3];
        }
        else if (PlayerData.Instance.mentalHealth >= 5)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[2];
        }
        else if (PlayerData.Instance.mentalHealth >= 3)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[1];
        }
        else if (PlayerData.Instance.mentalHealth <= 2)
        {
            endMental.GetComponent<Image>().sprite = mentalSprites[0];
        }
    }

    private void GetEndProductivity()
    {
        if (PlayerData.Instance.productivity >= 11)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[6];
        }
        else if (PlayerData.Instance.productivity >= 9)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[5];
        }
        else if (PlayerData.Instance.productivity >= 7)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[4];
        }
        else if (PlayerData.Instance.productivity >= 5)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[3];
        }
        else if (PlayerData.Instance.productivity >= 3)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[2];
        }
        else if (PlayerData.Instance.productivity >= 1)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[1];
        }
        else if (PlayerData.Instance.productivity <= 0)
        {
            endProductivity.GetComponent<Image>().sprite = productivitySprites[0];
        }
    }
}
