using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDayNext : MonoBehaviour
{
    public GameObject currentScreen ,nextScreen;

    public void NextScreen()
    {
        nextScreen.SetActive(true);
        currentScreen.SetActive(false);
    }
}
