using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDayNext : MonoBehaviour
{
    public GameObject currentScreen, nextScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextScreen();
        }
    }

    public void NextScreen()
    {
        nextScreen.SetActive(true);
        currentScreen.SetActive(false);
    }
}
