using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private int titleScreen;
    [SerializeField] private int introScreen;
    [SerializeField] private int mainScene;
    [SerializeField] private int endScreen;
    public void LoadMainScene()
    {
        SceneManager.LoadScene(mainScene);
    }
    public void LoadIntroScreen()
    {
        SceneManager.LoadScene(introScreen);
    }
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(titleScreen);
    }
    public void LoadEndScreen()
    {
        SceneManager.LoadScene(endScreen);
    }
    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber); 
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
