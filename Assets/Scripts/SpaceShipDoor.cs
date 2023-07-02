/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Space ship door animation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipDoor : MonoBehaviour
{
    /// <summary>
    /// On trigger function
    /// </summary>

  void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") // if tag is player
        {
            GetComponent<Animator>().SetTrigger("OpenDoor"); // run animation
        }
    }
    /// <summary>
    /// Exit the trigger 
    /// </summary>


    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player") // if tag is player
        {
            GetComponent<Animator>().SetTrigger("CloseDoor"); // run animation
        }
    }
}
