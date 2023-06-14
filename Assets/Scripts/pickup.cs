using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject GunOnPlayer;

    void Start()
    {
        GunOnPlayer.SetActive(false);
    }

    private void onTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E)) // if E is press, disable the gun in the scene
            {
                this.gameObject.SetActive(false);
                GunOnPlayer.SetActive(true);
            }
        }
    }
}
