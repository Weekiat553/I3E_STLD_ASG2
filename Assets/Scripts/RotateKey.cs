using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKey : MonoBehaviour
{
    public void buttionMethode()
    {
        GetComponent<Animator>().SetTrigger("TriggerKey");
    }
    public void buttionMethodee()
    {
        GetComponent<Animator>().SetTrigger("UnlockBoss");
    }
}
