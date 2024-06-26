using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    public static GamePauseManager instance;

    public GameObject menu;
    public GameObject dieMenu;
    public static bool isPaused = false;

    public KeyCode k_escape = KeyCode.Escape;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           // Destroy(this.gameObject);
        }
       
    }
    private void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(k_escape))
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
        CursorManager.UnlockCursor(); 
    }
    public void DieGame()
    {
        
        dieMenu.SetActive(true);
        Time.timeScale = 0f;
        CursorManager.UnlockCursor();
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        CursorManager.LockCursor(); 
    }

}
