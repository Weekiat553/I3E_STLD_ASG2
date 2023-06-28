using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    public GameObject gate;
    Raycast script;


    void Start()
    {
        script = FindObjectOfType<Raycast>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Debug.Log("1");
                if (script.Key)
                {
                    Debug.Log("SUp");
                    GetComponent<Animator>().SetTrigger("OpenDoor");
                }
            }
        }
    }
}
    