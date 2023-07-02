using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject DeathUi;
    //public bool resetHealth = false;
    //public HealthBar HealthBar;
    //PlayerHealth script;
    HealthBar healthbar;
    player pscript;
    public bool res = false;
    // Start is called before the first frame update
    void Start()
    {
        //script = FindObjectOfType<PlayerHealth>();
        healthbar = FindObjectOfType<HealthBar>();
        pscript = FindObjectOfType<player>();
    }

    // Update is called once per frame
    public void respawn()
    {
       // Debug.Log("Respawn");
        pscript.CurrentHealth = 100f;
        healthbar.slider.value = 100f;
        SceneManager.LoadScene(1);
        DeathUi.SetActive(false);
        pscript.CrossHair.SetActive(false);
        Time.timeScale = 1f;
       // Debug.Log(script.CurrentHealth);
        //Debug.Log(script.MaxHealth);
       //script.CurrentHealth = script.MaxHealth;
       // Debug.Log(script.CurrentHealth);
        
        //Debug.Log(healthbar.slider.value);
        pscript.iWanDie = false;
        res = true;

    }
}
