/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Open door script
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{
    /// <summary>
    /// Function to run when its triggered
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        
        GetComponent<Animator>().SetTrigger("OpenDoor");
    }
}
