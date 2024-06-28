using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndOfWeekScreen : MonoBehaviour
{
    public GameObject NextScreen;
    [SerializeField] private float schoolDays, finalAcademics;
    public TextMeshProUGUI academicsEndingTitle, academicsEndingText, mentalEndingTitle, mentalEndingText;
    public GameObject endMental, endMentalImage, endAcademics, endAcademicsImage;
    private GameObject startMental, startAcademics;
    [SerializeField] private Sprite[] mentalSprites;
    [SerializeField] private Sprite[] productivitySprites;
    [SerializeField] private Sprite[] endingSprites;
    public string acadText, acadText1, acadText2, acadText3, mentalText, mentalText1, mentalText2, mentalText3,
        acadTitle, acadTitle1, acadTitle2, acadTitle3, mentalTitle, mentalTitle1, mentalTitle2, mentalTitle3;
    
    /*
    void Update()
    {
        //text = GetComponent<TextMeshProUGUI>();

        GetAcademics();
        GetMental();

        text.text = "By the end of the day, Aria thinks she" + acadText
            + "\n\nAs her body hits the bed, she" + mentalText;
        //made some progress today.\r\nAs her body hits the bed, she feels tired and promptly falls asleep.";

        GetStartMental();
        GetStartAcademics();
        GetEndMentalSprite();
        GetEndAcademicsSprite();
    }
    */

    private void OnEnable()
    {
        ComputeFinalAcademics();
        GetEndAcademicsSprite();
        GetAcademics();
        GetEndMentalSprite();
        GetMental();
        NextScreen.SetActive(false);
    }

    private void ComputeFinalAcademics()
    {
        finalAcademics = (PlayerData.Instance.academics / schoolDays);
    }

    private void GetAcademics()
    {
        if (finalAcademics <= 6)
        {
            acadTitle = acadTitle3;
            acadText = acadText3;
            endAcademicsImage.GetComponent<Image>().sprite = endingSprites[2];
        }
        else if (finalAcademics <= 9)
        {
            acadTitle = acadTitle2;
            acadText = acadText2;
            endAcademicsImage.GetComponent<Image>().sprite = endingSprites[1];
        }
        else if (finalAcademics <= 12)
        {
            acadTitle = acadTitle1;
            acadText = acadText1;
            endAcademicsImage.GetComponent<Image>().sprite = endingSprites[0];
        }
        academicsEndingTitle.text = acadTitle;
        academicsEndingText.text = acadText;
    }

    private void GetMental()
    {
        if (PlayerData.Instance.mentalHealth <= 4)
        {
            mentalTitle = mentalTitle3;
            mentalText = mentalText3;
            endMentalImage.GetComponent<Image>().sprite = endingSprites[5];
        }
        else if (PlayerData.Instance.mentalHealth <= 7)
        {
            mentalTitle = mentalTitle2;
            mentalText = mentalText2;
            endMentalImage.GetComponent<Image>().sprite = endingSprites[4];
        }
        else if (PlayerData.Instance.mentalHealth <= 10)
        {
            mentalTitle = mentalTitle1;
            mentalText = mentalText1;
            endMentalImage.GetComponent<Image>().sprite = endingSprites[3];
        }

        if (PlayerData.Instance.skipCount >= 3) // override mentalHealth level if skipCount >= 3
        {
            mentalTitle = mentalTitle3;
            mentalText = mentalText3;
            endMentalImage.GetComponent<Image>().sprite = endingSprites[5];
        }
        mentalEndingTitle.text = mentalTitle;
        mentalEndingText.text = mentalText;
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

    private void GetStartAcademics()
    {
        if (PlayerData.Instance.startAcademics >= 11)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[6];
        }
        else if (PlayerData.Instance.startAcademics >= 9)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[5];
        }
        else if (PlayerData.Instance.startAcademics >= 7)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[4];
        }
        else if (PlayerData.Instance.startAcademics >= 5)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[3];
        }
        else if (PlayerData.Instance.startAcademics >= 3)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[2];
        }
        else if (PlayerData.Instance.startAcademics >= 1)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[1];
        }
        else if (PlayerData.Instance.startAcademics <= 0)
        {
            startAcademics.GetComponent<Image>().sprite = productivitySprites[0];
        }
    }

    private void GetEndMentalSprite()
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

    private void GetEndAcademicsSprite()
    {
        if (finalAcademics >= 11)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[6];
        }
        else if (finalAcademics >= 9)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[5];
        }
        else if (finalAcademics >= 7)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[4];
        }
        else if (finalAcademics >= 5)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[3];
        }
        else if (finalAcademics >= 3)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[2];
        }
        else if (finalAcademics >= 1)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[1];
        }
        else if (finalAcademics <= 0)
        {
            endAcademics.GetComponent<Image>().sprite = productivitySprites[0];
        }
    }
}
