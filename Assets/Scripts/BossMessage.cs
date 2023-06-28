using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMessage : MonoBehaviour
{
   public GameObject Msg;

   private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player")
        {
            Msg.SetActive(true);
        }
    }
}
