/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Run horizontal Elevator animation
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleCorssBtn : MonoBehaviour
{
    /// <summary>
    /// Ganeobject for hidden floating platforms
    /// </summary>
    public GameObject platform;
    public void buttionMethode()
    {

        //Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("corss1"); // trigger animation
        platform.SetActive(true); // show platforms
    }
}
