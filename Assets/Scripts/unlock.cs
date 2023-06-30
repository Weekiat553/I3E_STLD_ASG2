using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlock : MonoBehaviour
{
    public GameObject gate;
    public AudioSource GateSound;
    player script;

     
    void Start()
    {
        script = FindObjectOfType<player>();
    }


    public void UnlockGate()
    {
                Debug.Log("1");
                if (script.Key)
                {
                    Debug.Log("SUp");
                    GateSound.Play();
                    GetComponent<Animator>().SetTrigger("OpenDoor");
                }
            
        
    }
}
    