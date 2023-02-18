
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button exit;
    public Button toMainMenu;
    private bool isPaused = false;

    private void Start()
    {
        exit.onClick.AddListener(() => {
            Application.Quit();
        }); 
        toMainMenu.onClick.AddListener(() => {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        });
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {  
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
