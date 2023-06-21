using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonGuard : MonoBehaviour
{
    public GameObject GuardOne;
    public GameObject GuardTwo;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GuardOne.SetActive(true);
            GuardTwo.SetActive(true);
        }
    }
}
