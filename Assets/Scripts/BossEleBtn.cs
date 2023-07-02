/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Trigger boss tower elevator
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEleBtn : MonoBehaviour
{
    /// <summary>
    /// When function is calledm will trigger animation for the boss tower elevator
    /// </summary>
    public void buttionMethode()
    {

        //Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("BossEle");

    }
}
