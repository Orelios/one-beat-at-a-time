using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineNextScene : MonoBehaviour
{
    public ScreenManager sceneManager;
    public SceneNumber objectToLoad;
    private void OnEnable()
    {
        sceneManager.LoadLevel(objectToLoad.sceneNumber);
    }
}
