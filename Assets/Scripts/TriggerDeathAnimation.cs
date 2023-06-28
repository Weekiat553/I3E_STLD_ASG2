using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathAnimation : MonoBehaviour
{
    PlayerHealth script;
    
    public void playAnimation()
    {
        if (script.death)
        {
            GetComponent<Animator>().SetTrigger("EDeathTrigger");
        }
    }
}
