using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject DeathUi;
    public bool resetHealth = false;
    PlayerHealth script;
    // Start is called before the first frame update
    void Start()
    {
        script = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    public void respawn()
    {
        Debug.Log("Respawn");
        script.CurrentHealth += 100f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DeathUi.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log(script.CurrentHealth);
        Debug.Log(script.MaxHealth);
        script.CurrentHealth = script.MaxHealth;
        Debug.Log(script.CurrentHealth);
    }
}
