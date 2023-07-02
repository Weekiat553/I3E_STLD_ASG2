/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Trigger ball script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBall : MonoBehaviour
{
   /// <summary>
   /// Function run when in contact with something
   /// </summary>

   private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Heyd");
        if (other.gameObject.tag == "Player") // If tag is player
        {
            //Debug.Log("Hey");
            GetComponent<Animator>().SetTrigger("BallTrigger"); // run the animation
            
        }
    }
}
