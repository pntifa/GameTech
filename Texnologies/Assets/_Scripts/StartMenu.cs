using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the next scene, the game
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit(); //Quits the application
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Load the options menu
    }
}
