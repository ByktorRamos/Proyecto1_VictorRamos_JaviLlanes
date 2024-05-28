using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void QuitGame() 
    {
        Application.Quit();
        UnlockCursor();
    }
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ReplayButton()
    {

        SceneManager.LoadScene("MainScene");
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;

    }
   
}
