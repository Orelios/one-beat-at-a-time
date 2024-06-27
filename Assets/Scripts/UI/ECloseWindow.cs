using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECloseWindow : MonoBehaviour
{
    public GameObject dayChange;
    private bool whileEventActive = false; 
    void Update()
    {
        if (!dayChange.activeSelf){ whileEventActive = true; }

        if(whileEventActive == true){Time.timeScale = 0.0f;}

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            whileEventActive = false;
            gameObject.SetActive(false);
            Time.timeScale = 1.0f; 
        }
    }

    public void SetObjectToFalse() 
    {
        whileEventActive = false;
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
