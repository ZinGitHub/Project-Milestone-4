using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Boolean variable to check if game is paused
    public static bool gameIsPaused = false;
    // Gameoject component attached to game over menu UI
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    { 
        // Once the user clicks the p button on their keyboard it will execute the resume or pause function
        if(Input.GetKeyDown(KeyCode.P))
        {
            // An if statement for when the player had already pressed the p button on the keyboard to pause will unpause
            if(gameIsPaused)
            {
                // Resume function recall (will unpause the game)
                Resume();
            }
            // Else statement in case the player has already not paused the game
            else
            {
                // Pause function recall (will pause the game)
                Pause();
            }
        }
    }

    // Function definition for Resume
    public void Resume()
    {
        // Remove the pause menu UI 
        pauseMenuUI.SetActive(false);
        // Resume all movement back to normal in the game
        Time.timeScale = 1f;
        // Switch/set boolean variable to false to tell the game that the game is not paused as of now
        gameIsPaused = false;
    }

    // Function definition for Pause
    void Pause()
    {
        // Display the pause menu UI
        pauseMenuUI.SetActive(true);
        // Halt all movement in the game
        Time.timeScale = 0f;
        // Switch/set boolean variable to true to tell the game that the game is paused as of now
        gameIsPaused = true;
    }

    // Function definition for LoadMenu
    public void LoadMenu()
    {
        // Resume all movement back to normal in the game
        Time.timeScale = 1f;
        // Load the "Start Menu" scene when player clicks the option button in the pause UI
        SceneManager.LoadScene("Pause Settings");
    }

    // Function definition for QuitGame
    public void QuitGame()
    {
        // Take back to main menu
        SceneManager.LoadScene("Start Menu");
    }

    // Function definition for ReturnGame
    public void ReturnGame()
    {
        SceneManager.LoadScene("Main");
    }
}
