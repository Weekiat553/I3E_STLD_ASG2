/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Menu page script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// Main menu screen 
    /// </summary>
    public GameObject MainMenu;

    /// <summary>
    ///How to play screen screen 
    /// </summary>
    public GameObject Htp;

    /// <summary>
    /// Option screen 
    /// </summary>
    public GameObject Option;

    /// <summary>
    /// Credit scene
    /// </summary>
    public GameObject Credit;

    /// <summary>
    /// Audio for game
    /// </summary>
    public AudioSource MenuSound;

    /// <summary>
    /// Audio mixer to to retrieve the volume adjuster
    /// </summary>
    public AudioMixer mainMixer;
    // Start is called before the first frame update


    /// <summary>
    /// Run play button
    /// </summary>
    public void PlayGame ()
    {
        MenuSound.Play(); // play menu sound
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // go to game scene
    }

    /// <summary>
    /// Run how to play button
    /// </summary>
    public void GoHowToPlay()
    {
        MenuSound.Play(); // play menu sound
        MainMenu.SetActive(false); // Hide main menu
        Htp.SetActive(true); // show how to play page
    }

    /// <summary>
    /// Run options button
    /// </summary>
    public void GoOption()
    {
        MenuSound.Play(); // play menu sound
        MainMenu.SetActive(false); // hide main menu
        Option.SetActive(true); // Show option page
    }

    /// <summary>
    /// Run credit button
    /// </summary>
    public void GoCredit()
    {
        MenuSound.Play(); // play menu sound
        MainMenu.SetActive(false); // hide main menu
        Credit.SetActive(true); // show credit page
    }

    /// <summary>
    /// Go back to menu
    /// </summary>
    public void GoMenu()
    {
        MenuSound.Play();  // play menu sound
        Credit.SetActive(false); // hide credit
        Option.SetActive(false); // hide option
        Htp.SetActive(false); // hide how to play
        MainMenu.SetActive(true); // show main menu
    }
    /// <summary>
    /// Quit the game
    /// </summary>
    public void GoQuit()
    {
        Application.Quit(); // close the app
    }

    /// <summary>
    /// Adjust game bgm
    /// </summary>
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume); // link to volume in the mixer
    }
}
