using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void LoadPregame()
    {
        SceneManager.LoadScene("PregameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
