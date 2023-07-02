/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Spawn player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    /// <summary>
    /// Gameobject for prefab player
    /// </summary>
    public GameObject playerPrefab;

    /// <summary>
    /// Retrieve player script
    /// </summary>
    private player activePlayer;

    /// <summary>
    /// Retrieve respawn script
    /// </summary>
    Respawn script;


    public static GameManager instance;

    /// <summary>
    /// Run the following code at the start
    /// </summary>
   void Start()
    {
        script = FindObjectOfType<Respawn>(); // Retrieve respawn script
    }

    /// <summary>
    /// Runs before the start function
    /// </summary>
    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject); //Destroy player
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += SpawnPlayerOnScreenLoad;
            instance = this;
        }

       




    }
    /// <summary>
    /// Spawn on load function
    /// </summary>
    private void SpawnPlayerOnScreenLoad(Scene curScene, Scene next)
    {
        if(next.buildIndex == 0)
        {
            if(activePlayer != null)
            {
                Destroy(activePlayer.gameObject);
                activePlayer = null;
            }

            return;

        if(next.buildIndex == 1)
            {
                Destroy(activePlayer.gameObject);
                activePlayer = null;
            }

        }


        spawn spawnpoint = FindObjectOfType<spawn>();  // Find spawn point to spawn player
        if (activePlayer == null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, spawnpoint.transform.position, Quaternion.identity);
            activePlayer = newPlayer.GetComponent<player>();
            
        }
        else
        {
            activePlayer.transform.position = spawnpoint.transform.position;
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
