using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETutorialToRhythm : MonoBehaviour
{
    public ScreenManager manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            manager.LoadNextScene();
        }
    }
}
