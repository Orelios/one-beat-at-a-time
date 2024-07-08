using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EUniqueToNext : MonoBehaviour
{
    public ScreenManager manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerData.Instance.IncrementOverworldScene();
            PlayerData.Instance.Save();
            //Debug.Log("overworldScene = " + PlayerData.Instance.overworldScene);
            manager.LoadNextScene();
        }
    }
}
