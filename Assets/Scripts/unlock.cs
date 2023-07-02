/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Unlock civilization gate script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    /// <summary>
    /// Store gate
    /// </summary>
    public GameObject gate; 

    /// <summary>
    /// Retrieve gate audio sound
    /// </summary>
    public AudioSource GateSound;

    /// <summary>
    /// Store player script
    /// </summary>
    player script;

     /// <summary>
     /// Run at the start
     /// </summary>
    void Start()
    {
        script = FindObjectOfType<player>(); // store player script
    }

    /// <summary>
    /// Run unlock gate when function is called
    /// </summary>
    public void UnlockGate()
    {
                //Debug.Log("1");
                if (script.Key) // if key is true
                {
                    //Debug.Log("SUp");
                    GateSound.Play(); // play gate sound
                    GetComponent<Animator>().SetTrigger("OpenDoor"); // run gate animation
                }
            
        
    }
}
    