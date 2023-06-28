using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{
 
    
    public GameObject CrossHair;
    public GameObject PlayerGun;
    public Transform head;
    Camera cam;
    bool mouseClick = false;
    public GameObject button;
    public GameObject sphere;
    public GameObject gen;
    public GameObject healthgen;
    public GameObject balls;
    public GameObject reactor;
    public bool keyboss = false;
    int count = 0;
    public bool Key = false;

    // Start is called before the first frame update

    void Start()
    {
        cam = Camera.main;
        print(cam.name);
    }


    void Update()
    {
        

        /// Draw ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        Debug.DrawLine(transform.position, transform.position);

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "gun")
            {
                //pickGun = true;
                PlayerGun.SetActive(true);
                CrossHair.SetActive(true);

            }

            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "KeyOne")
            {
                Destroy(hit.collider.gameObject);
                Key = true;
            }
            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "KeyTwo")
            {
                Destroy(hit.collider.gameObject);
                keyboss = true;
                Debug.Log("True");
            }

            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "Sphere")
            {
                Destroy(hit.collider.gameObject);
                sphere.SetActive(true);
                count += 1;
            }
            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "Gen")
            {
                gen.SetActive(true);
                Destroy(hit.collider.gameObject);
                count += 1;
            }
            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "Reactor")
            {
                reactor.SetActive(true);
                Destroy(hit.collider.gameObject);
                count += 1;
            }
            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "Healthgen")
            {
                healthgen.SetActive(true);
                Destroy(hit.collider.gameObject);
                count += 1;

            }
            else if (Physics.Raycast(ray, out hit, 10) && hit.collider.tag == "Balls")
            {
                balls.SetActive(true);
                Destroy(hit.collider.gameObject);
                count += 1;
            }
        }

    }



}

