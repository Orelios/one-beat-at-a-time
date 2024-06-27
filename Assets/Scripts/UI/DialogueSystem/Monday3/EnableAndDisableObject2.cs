using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisableScript2 : MonoBehaviour
{
    public ScreenManager scene; 
    public void EnableObject()
    {
        gameObject.SetActive(true); 
    }

    public void DisableObject()
    {
        gameObject.SetActive(false); 
    }

    private void OnDisable()
    {
        scene.LoadNextScene();
    }
}
