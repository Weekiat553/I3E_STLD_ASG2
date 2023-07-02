/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Boss gate animation script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlocBossTower : MonoBehaviour
{
    /// <summary>
    /// Run the gate animation when function is called 
    /// </summary>
    public void buttionMethode()
    {

        //Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("BossEle"); // Run animation

    }
}
