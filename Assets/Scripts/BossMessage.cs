/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Display msg
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMessage : MonoBehaviour
{
    /// <summary>
    /// Gameobject for message
    /// </summary>
    public GameObject Msg;

    /// <summary>
    /// Trigger function when player comes in contact with the box
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player") //If detect tag player, 
        {
            Msg.SetActive(true); // Show Message
        }
    }
}
