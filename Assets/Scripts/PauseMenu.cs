/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Pause menu script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Pause menu 
    /// </summary>
    public GameObject pauseMenu;

    /// <summary>
    /// Bool set when pausing
    /// </summary>
    public static bool GameIsPaused = false;

    /// <summary>
    /// Retrieve audio
    /// </summary>
    public AudioSource MenuSound;

    /// <summary>
    /// Run pause button
    /// </summary>
    public void pauseGame()
    {
        MenuSound.Play(); // Play menu sound
        //Debug.Log("Pause");
        Time.timeScale = 0f; // Freeze game
        pauseMenu.SetActive(true); // Show pause menu
        GameIsPaused = true; 
        

    }
    /// <summary>
    /// Run resume button
    /// </summary>
    public void resumeGame()
    {
        MenuSound.Play(); // Play menu sound
        pauseMenu.SetActive(false); // hide pause menu
        Time.timeScale = 1f; // unfreeze time
        GameIsPaused = false;
    }

    /// <summary>
    /// Run quit button
    /// </summary>
    public void quitGame()
    {
        MenuSound.Play(); // Play menu sound
        SceneManager.LoadScene(0); // Go to menu

    }
}
