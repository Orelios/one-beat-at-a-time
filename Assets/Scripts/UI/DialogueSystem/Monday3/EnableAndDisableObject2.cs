using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisableScript2 : MonoBehaviour
{
    public ScreenManager scene;
    public GameObject dialogue2, dialogue3, dialogue, offset; 
    public void EnableObject()
    {
        dialogue2.gameObject.SetActive(true); 
    }

    public void EnableObject3()
    {
        dialogue3.gameObject.SetActive(true);
    }

    public void DisableObject()
    {
        dialogue2.gameObject.SetActive(false);
        dialogue3.gameObject.SetActive(false);
        PlayerData.Instance.IncrementOverworldScene();
        PlayerData.Instance.Save();
        scene.LoadNextScene();
    }

    private void Update()
    {
        if(!dialogue2.activeSelf && !dialogue3.activeSelf && !dialogue.activeSelf && !offset.activeSelf) { DisableObject(); }
    }
}
