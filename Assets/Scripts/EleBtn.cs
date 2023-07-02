/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Run Elevator animation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EleBtn : MonoBehaviour
{

    // public Raycast script;
    // Start is called before the first frame update
    /// <summary>
    /// Run elevator animation when the function is called
    /// </summary>
    public void buttionMethode()
    {
        //Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("ElevatorButton");

    }
}
