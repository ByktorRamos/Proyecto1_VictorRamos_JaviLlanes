using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    public GameObject menu;
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
                PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            
                ResumeGame();
        }
    }

    void PauseGame()
    {
        menu.SetActive(true);

        Time.timeScale = 0f; 
    }

    public void ResumeGame()
    {
        menu.SetActive(false);

        Time.timeScale = 1f; 
    }
}
