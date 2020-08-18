using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function definition for PlayGame
    public void PlayGame()
    {
        // Load the main (game) scene once player clicks the play gutton
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function definition for QuitGame
    public void QuitGame()
    {
        // Debug log to just test if the quit button works
        Debug.Log("Game Quit");
        // Quit and close the Unity game application once user clicks quit button
        Application.Quit();
    }

}
