 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBall : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Heyd");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hey");
            GetComponent<Animator>().SetTrigger("BallTrigger");
            
        }
    }
}
