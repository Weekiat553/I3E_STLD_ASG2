/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Display text script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    /// <summary>
    /// Store spaceship text
    /// </summary>
    public GameObject TpToSpaceShip;

    /// <summary>
    /// Store key prompt text
    /// </summary>
    public GameObject KeyPrompt;
    // Update is called once per frame

    /// <summary>
    /// Store player script
    /// </summary>
    player script;

    /// <summary>
    /// Run function at the start
    /// </summary>
    void Start()
    {
        script = FindObjectOfType<player>(); // retrieve player script
    }
    void OnTriggerEnter(Collider other) // When in contact with the collider
    {
        if (other.gameObject.tag == "Player") // if tag is player
        {
            if (script.Count == 6) // player count is 6
            {
                //TpToSpaceShip.SetActive(true);
            }
            
            if (script.Count <= 5) // if count is less than or equal to 5
            {
                KeyPrompt.SetActive(true); // show message
            }
        }
        
    }
    void OnTriggerExit(Collider other) // when is not in contact with the collider
        {
            //TpToSpaceShip.SetActive(false);
            KeyPrompt.SetActive(false); // hide message
        }
}
