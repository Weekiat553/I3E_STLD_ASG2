using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKey : MonoBehaviour
{
    public GameObject doors;
    public bool Key = false;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KeyOne")
        {
            Destroy(collision.gameObject);
            Key = true;
        }
    }
        public void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "KeyOne")
            {
                Debug.Log("Stay :" + collision.gameObject.name);
            }

        }

        public void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "KeyOne")
            {
                Debug.Log("Exit :" + collision.gameObject.name);
            }

        }



        // Update is called once per frame
        void Update()
        {

        }

}
