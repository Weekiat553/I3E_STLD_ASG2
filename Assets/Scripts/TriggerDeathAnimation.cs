/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Trigger death animation script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerDeathAnimation : MonoBehaviour
{
    /// <summary>
    /// Retrieve player script
    /// </summary>
    player script;

    /// <summary>
    /// Retrieve respawn script
    /// </summary>
    Respawn rscript;

    /// <summary>
    /// Store deathui
    /// </summary>
    public GameObject DeathUi;

    /// <summary>
    /// Count down for death
    /// </summary>
    private int CountDown = 2;

    /// <summary>
    /// Run function when start
    /// </summary>
    void Start()
    {
        script = FindObjectOfType<player>(); // retrieve player script
        rscript = FindObjectOfType<Respawn>(); // retrieve respawn script
    }

    /// <summary>
    /// Run death animation when function is called
    /// </summary>
    public void playAnimation() 
    {
        if (script.CurrentHealth <= 0) // if health is less than or 0
        {
            //Debug.Log("Hey");
            GetComponent<Animator>().SetTrigger("EDeathTrigger"); // run animation
            DeathUi.SetActive(true); // show death ui
        }
    
        

        
        if (CountDown >= 0) // if count down is not 0 or more than 0
        {
            CountDown -= 1;  //-1
        }
        else
        {
            Time.timeScale = 0f; // freeze time
        }
    }
    /// <summary>
    /// Run when update
    /// </summary>
    void Update()
    {
        if(rscript.res) // retrieve res from player
        {
            GetComponent<Animator>().SetTrigger("Revive"); // run revive animation
        }
    }
}
