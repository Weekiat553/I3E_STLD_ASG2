using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossKey : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;
    public GameObject key;
    public bool unlock = false;
    Raycast script;
    void Start()
    {
        button = this.gameObject;
        script = FindObjectOfType<Raycast>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                Debug.Log("1");
                if (script.keyboss)
                {
                    Debug.Log("2");
                    key.SetActive(true);
                    unityEvent.Invoke();
                    unlock = true;
                }
            }
        }
    }
}
