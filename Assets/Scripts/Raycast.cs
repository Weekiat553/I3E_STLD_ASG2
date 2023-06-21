using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
 
    
    public GameObject CrossHair;
    public GameObject PlayerGun;
    //public bool pickGun = false;
    public Transform head;
    Camera cam;
    bool mouseClick = false;
    // Start is called before the first frame update

    void Start()
    {
        cam = Camera.main;
        print(cam.name);
    }


    void Update()
    {
        

        // Draw ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        Debug.DrawLine(transform.position, transform.position);

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100) && hit.collider.tag == "gun")
            {
                //pickGun = true;
                PlayerGun.SetActive(true);
                CrossHair.SetActive(true);
            }
        }
    }



}

