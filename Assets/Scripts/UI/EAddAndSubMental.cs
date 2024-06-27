using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAddAndSubMental : MonoBehaviour
{
    public ScreenManager manager;
    public int mentalAmount; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerData.Instance.IncrementOverworldScene();
            AddAndSubtractMental.Instance.AddOrSubMental(mentalAmount);
            PlayerData.Instance.Save();            
            manager.LoadNextScene();
        }
    }

    public void AddMental()
    {
        PlayerData.Instance.IncrementOverworldScene();
        AddAndSubtractMental.Instance.AddOrSubMental(5);
        PlayerData.Instance.Save();
        manager.LoadNextScene();
    }
    public void SubtractMental()
    {
        PlayerData.Instance.IncrementOverworldScene();
        AddAndSubtractMental.Instance.AddOrSubMental(-5);
        PlayerData.Instance.Save();
        manager.LoadNextScene();
    }
}
