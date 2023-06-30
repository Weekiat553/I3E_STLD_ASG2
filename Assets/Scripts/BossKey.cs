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
    player pscript;
    void Start()
    {
        button = this.gameObject;
        pscript = FindObjectOfType<player>();
    }

    // Update is called once per frame
    public void UnlockBoss()
    {
       
                if (pscript.Count == 5)
                {
                    Debug.Log("1");
                    if (script.keyboss)
                    {
                        Debug.Log("2");
                        key.SetActive(true);
                        unityEvent.Invoke();
                        unlock = true;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (pscript.Count <= 5)
                {
                    return;
                }
            
        
    }
}
