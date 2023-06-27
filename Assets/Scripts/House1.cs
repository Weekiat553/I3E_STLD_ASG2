using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House1 : MonoBehaviour
{
    //public GameObject platform;
    public void buttionMethode()
    {

        Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("house1");
        
    }
}
