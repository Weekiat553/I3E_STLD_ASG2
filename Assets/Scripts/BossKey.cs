/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Unlocking boss tower entrance
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossKey : MonoBehaviour
{
    /// <summary>
    /// Using of UnityEvent
    /// </summary>
    public UnityEvent unityEvent = new UnityEvent();

    /// <summary>
    /// GameObject for button
    /// </summary>
    public GameObject button;

    /// <summary>
    /// Gameobject for a hidden key
    /// </summary>
    public GameObject key;

    /// <summary>
    /// boolean for unlock
    /// </summary>
    public bool unlock = false;

    /// <summary>
    /// Retrieve from script Raycast
    /// </summary>
    //Raycast script;

    /// <summary>
    /// Retrieve from player script
    /// </summary>
    player pscript;


    /// <summary>
    /// Function to run the following code below
    /// </summary>
    void Start()
    {
        button = this.gameObject;
        pscript = FindObjectOfType<player>(); //Store player script under pscript;
    }

    /// <summary>
    /// Unlock Boss function
    /// </summary>
    public void UnlockBoss()
    {
       
                if (pscript.Count == 5) // if count from player script is = 5, it will run the following code below
                {
                    //Debug.Log("1");
                    if (pscript.keyboss) // if keyboss from player script is true, it will run the following 
                    {
                        Debug.Log("2");
                        key.SetActive(true); //Show the hidden key
                        unityEvent.Invoke(); // using of unityevent
                        unlock = true; // unlock become true
                    }
                    else
                    {
                        return;
                    }
                }
                else if (pscript.Count <= 5)
                {
                    return;
                }
            
        
    }
}
