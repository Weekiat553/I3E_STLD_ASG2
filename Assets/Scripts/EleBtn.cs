using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleBtn : MonoBehaviour
{

   // public Raycast script;
    // Start is called before the first frame update

    public void buttionMethode()
    {
        Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("ElevatorButton");

    }
}
