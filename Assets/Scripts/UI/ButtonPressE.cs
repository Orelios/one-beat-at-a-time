using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressE : MonoBehaviour
{
    public ScreenManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            manager.LoadIntroScreen();
        }
    }
}
