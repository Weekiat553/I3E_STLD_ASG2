using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Htp;
    public GameObject Option;
    public GameObject Credit;
    public AudioSource MenuSound;
    public AudioMixer mainMixer;
    // Start is called before the first frame update

    public void PlayGame ()
    {
        MenuSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoHowToPlay()
    {
        MenuSound.Play();
        MainMenu.SetActive(false);
        Htp.SetActive(true);
    }

    public void GoOption()
    {
        MenuSound.Play();
        MainMenu.SetActive(false);
        Option.SetActive(true);
    }

    public void GoCredit()
    {
        MenuSound.Play();
        MainMenu.SetActive(false);
        Credit.SetActive(true);
    }

    public void GoMenu()
    {
        MenuSound.Play();
        Credit.SetActive(false); 
        Option.SetActive(false);
        Htp.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }
}
