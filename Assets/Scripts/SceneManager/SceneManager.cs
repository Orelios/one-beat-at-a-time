using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private int titleScreen;
    [SerializeField] private int overworldScene;
    [SerializeField] private int nextScene;
    [SerializeField] private int endScreen;

    private void Start()
    {
        overworldScene = PlayerData.Instance.overworldScene;
    }

    public void LoadNextScene() //tutorial to rhythm AND Unique Event to next Overworld Scene
    {
        SceneManager.LoadScene(nextScene);
        Time.timeScale = 1.0f;
    }
    public void ReturnToOverworld()
    {
        SceneManager.LoadScene(overworldScene);
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
