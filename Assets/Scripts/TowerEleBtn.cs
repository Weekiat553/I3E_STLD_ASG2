/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Trigger tower elevator script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEleBtn : MonoBehaviour
{
    /// <summary>
    /// Run the animation when this function is called
    /// </summary>
    public void buttionMethode()
    {
        //Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("TowerElevator"); // Run animation

    }
}
