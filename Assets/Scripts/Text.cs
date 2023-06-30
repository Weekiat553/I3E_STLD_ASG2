using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    public GameObject TpToSpaceShip;
    public GameObject KeyPrompt;
    // Update is called once per frame
    player script;
    void Start()
    {
        script = FindObjectOfType<player>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (script.Count == 6)
            {
                //TpToSpaceShip.SetActive(true);
            }
            
            if (script.Count <= 5)
            {
                KeyPrompt.SetActive(true);
            }
        }
        
    }
    void OnTriggerExit(Collider other)
        {
            //TpToSpaceShip.SetActive(false);
            KeyPrompt.SetActive(false);
        }
}
