using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBall : MonoBehaviour
{
   public bool ball = false;
   private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            GetComponent<Animator>().SetTrigger("BallTrigger");
            Debug.Log("Hey");
        }
    }
}
