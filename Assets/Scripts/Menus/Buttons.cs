using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}
