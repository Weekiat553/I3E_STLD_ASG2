using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    public GameObject gate;
    public GateKey script;

    void OnTriggerEnter(Collider other)
    {
        if (script.Key)
        {
            GetComponent<Animator>().SetTrigger("OpenDoor");
        }

       
    }
        
}