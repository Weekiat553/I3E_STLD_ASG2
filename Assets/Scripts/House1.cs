/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Alien home elevator
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House1 : MonoBehaviour
{
    /// <summary>
    /// Trigger animation when function is called
    /// </summary>
    //public GameObject platform;
    public void buttionMethode()
    {

        //Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("house1"); // trigger alien home elevator
        
    }
}
