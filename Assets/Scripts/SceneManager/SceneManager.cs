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
        Time.timeScale = 1.0f;
    }
    public void LoadIntroScreen()
    {
        SceneManager.LoadScene(introScreen);
        Time.timeScale = 1.0f;
    }
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(titleScreen);
        Time.timeScale = 1.0f;
    }
    public void LoadEndScreen()
    {
        SceneManager.LoadScene(endScreen);
        Time.timeScale = 1.0f;
    }
    public void LoadLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
        Time.timeScale = 1.0f;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
