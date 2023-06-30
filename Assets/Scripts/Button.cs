using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    public GameObject Door;

    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    public void ButtonClicked()
    {
      /*  if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            { */
                unityEvent.Invoke();
          //  }
       // }
    }

    public void TreasureDoor()
    {
        unityEvent.Invoke();
    }
}
