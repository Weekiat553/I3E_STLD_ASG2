using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleCorssBtn : MonoBehaviour
{

    public GameObject platform;
    public void buttionMethode()
    {

        Debug.Log("Hello");
        GetComponent<Animator>().SetTrigger("corss1");
        platform.SetActive(true);
    }
}
