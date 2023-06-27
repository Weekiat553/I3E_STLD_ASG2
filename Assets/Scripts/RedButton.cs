using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public GameObject elevator;
    public bool Btn = false;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ElevatorBtn")
        {
            Destroy(collision.gameObject);
            Btn = true;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ElevatorBtn")
        {
            Debug.Log("Stay :" + collision.gameObject.name);
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ElevatorBtn")
        {
            Debug.Log("Exit :" + collision.gameObject.name);
        }

    }



    // Update is called once per frame
    void Update()
    {

    }

}
