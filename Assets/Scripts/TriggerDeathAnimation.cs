using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeathAnimation : MonoBehaviour
{
    PlayerHealth script;
    public GameObject DeathUi;
    private int CountDown = 2;
    void Start()
    {
        script = FindObjectOfType<PlayerHealth>();
    }

    public void playAnimation()
    {
        if (script.CurrentHealth <= 0)
        {
            //Debug.Log("Hey");
            GetComponent<Animator>().SetTrigger("EDeathTrigger");
            DeathUi.SetActive(true);
        }
        

        
        if (CountDown >= 0)
        {
            CountDown -= 1;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }


}
