using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Boolean variable to check condition on whether the game is paused or not
    public static bool gameIsPaused = false;
    // Gameoject component attached to game over menu UI
    public GameObject gameOverMenuUI;

    // Function definition for LoadMenu
    public void LoadMenu()
    {
        // Load the "Start Menu" Unity scene if user clicks return button
        SceneManager.LoadScene("Start Menu");
    }

    //Function definition for QuitGame
    public void QuitGame()
    {
        //  Quit the game if user clicks the quit button
        Application.Quit();
    }
}
