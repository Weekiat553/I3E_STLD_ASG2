using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform Cam;
    
    void Start()
    {
        Cam = FindObjectOfType<GetCam>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.forward);
    }
}
