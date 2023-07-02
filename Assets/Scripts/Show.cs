/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Show fixed item script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    /// <summary>
    /// Retrieve player script
    /// </summary>
    player script;

    /// <summary>
    /// store color health
    /// </summary>
    public GameObject Chealth;

    /// <summary>
    /// Store color gen
    /// </summary>
    public GameObject Cgen;

    /// <summary>
    /// Store color reactor
    /// </summary>
    public GameObject Creactor;

    /// <summary>
    /// Store color sphere
    /// </summary>
    public GameObject Csphere;

    /// <summary>
    /// Store displayed health 
    /// </summary>
    public GameObject health;

    /// <summary>
    /// Store displayed gen
    /// </summary>
    public GameObject gen;

    /// <summary>
    /// Store displayed reactor
    /// </summary>
    public GameObject reactor;

    /// <summary>
    /// Store displayed sphere
    /// </summary>
    public GameObject sphere;
    
    /// <summary>
    /// Run function at start
    /// </summary>
    void Start()
    {
        script = FindObjectOfType<player>(); // retrieve player script
    }

    /// <summary>
    /// Show gen function
    /// </summary>
    public void ShowGen()
    {

            Cgen.SetActive(true); // show color gen
            gen.SetActive(false); // hide displayed gen
        
    }
    /// <summary>
    /// Show sphere function
    /// </summary>
    public void ShowSphere()
    {

            Csphere.SetActive(true); // show color sphere
            sphere.SetActive(false); // hide color sphere
  

       
    }
    /// <summary>
    /// Show health function
    /// </summary>
    public void ShowHealth()
    {
 
            Chealth.SetActive(true); // show color health
            health.SetActive(false); // hide displayed health


        
    }
    /// <summary>
    /// Show reactor function
    /// </summary>
    public void ShowReactor()
    {
           Creactor.SetActive(true); //show color reactor
           reactor.SetActive(false); // hide displayed reactor
;
    }


}
