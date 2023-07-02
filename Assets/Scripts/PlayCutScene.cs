/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Play cut scene script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCutScene : MonoBehaviour
{
    /// <summary>
    /// Countdown to run function
    /// </summary>
    private int CountDown = 500;

    /// <summary>
    /// Store hidden menu
    /// </summary>
    public GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Run the function on update
    /// </summary>
    void Update()
    {
        GetComponent<Animator>().SetTrigger("Fly"); // Play spaceship fly animation
        if(CountDown >= 0 ) // if count down is more than 0
        {
            CountDown--; // -1
            //Debug.Log(CountDown);
        }
        else // else if its 0 or lesser than 0
        {
            Menu.SetActive(true); // Show Menu
        }
    }
    /// <summary>
    /// Run Menu button
    /// </summary>
    public void GoBackMenu()
    {
        SceneManager.LoadScene(0); // Go to Menu scene
    }
}
