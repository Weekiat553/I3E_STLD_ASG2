/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Unlock treasure script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTreasure : MonoBehaviour
{
    /// <summary>
    /// Store enemy script
    /// </summary>
    Enemy script; 

    /// <summary>
    /// Store treasure door
    /// </summary>
    public GameObject TreasureDoor;

    /// <summary>
    /// Run when on start
    /// </summary>
    void Start()
    {
        //Debug.Log("F");
        script = FindObjectOfType<Enemy>(); // Retrieve enemy script
    }

    // Update is called once per frame
    /// <summary>
    /// Run destroy door when function is called
    /// </summary>
    public void OpenTreasureDoor()
    {
        if (script.ded) // is ded is true
        {
            //Debug.Log("Test");
            Destroy(gameObject); //Destroy door
        }
    }

    void Update()
    {
        OpenTreasureDoor(); // run function
    }
}
