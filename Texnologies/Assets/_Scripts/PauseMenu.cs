using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerObject; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //when you press "Esc", your game pauses or resumes, depending
        {				      // on the current state
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //disable the Pause Menu UI
        Time.timeScale = 1f; //time is going normally
        GameIsPaused = false; //the game is not paused

        playerObject.SetActive(true); //the player is visible
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); //shows the Pause Menu UI
        Time.timeScale = 0f; //time is stopped
        GameIsPaused = true;

        playerObject.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Options Menu"); //loads the scene Options Menu when you press "Menu"
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //Quits the game
    }
}
