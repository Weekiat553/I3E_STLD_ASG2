using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GameIsPaused = false;
    public AudioSource MenuSound;
    public void pauseGame()
    {
        MenuSound.Play();
        Debug.Log("Pause");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        

    }

    public void resumeGame()
    {
        MenuSound.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
