/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Clickable buttons script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    /// <summary>
    /// Using of UnityEvent
    /// </summary>
    public UnityEvent unityEvent = new UnityEvent();

    /// <summary>
    /// GameObject for Button
    /// </summary>
    public GameObject button;
    //public GameObject Door;

    /// <summary>
    /// Function to run the following code below
    /// </summary>
    void Start()
    {
        button = this.gameObject; // Button is current object
    }

    /// <summary>
    /// Run button clicked when function is called
    /// </summary>
    public void ButtonClicked()
    {
      /*  if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            { */
                unityEvent.Invoke(); // Run unityEvent
          //  }
       // }
    }

    public void TreasureDoor()
    {
        unityEvent.Invoke(); // Run unityEvent
    }
}
