using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bang;

    public void Collected()
    {
        Destroy(gameObject);
    }
}
