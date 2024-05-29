using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    public GameObject menu;
    public static bool isPaused = false;

    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && isPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        CursorManager.UnlockCursor(); // Llamar a un método estático para desbloquear el cursor
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        CursorManager.LockCursor(); // Llamar a un método estático para bloquear el cursor
    }

}
