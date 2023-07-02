/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Play key and door animation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKey : MonoBehaviour
{
    /// <summary>
    /// Run key animation when the function is called
    /// </summary>
    public void buttionMethode()
    {
        GetComponent<Animator>().SetTrigger("TriggerKey"); // play key animation
    }

    /// <summary>
    /// Run door animation when the function is called
    /// </summary>
    public void buttionMethodee()
    {
        GetComponent<Animator>().SetTrigger("UnlockBoss"); // play door animation
    }
}
