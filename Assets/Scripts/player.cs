using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //Movement speed
    Vector3 movementInput = Vector3.zero;
    public float movementSpeed;
    //Rotation speed
    Vector3 rotationInput = Vector3.zero;
    public float rotationSpeed = 1f;

    int score = 0; // total score
    public int pts = 1; // coin pts
    public int minuspts = 1; // minus point
    public int helmetpts = 1; // pts for helmet
    public int cardpts = 5; // pts for card
    public int swordpts = 6; // pts for sword
    public int gunpts = 7; // pts for gun
    public int scouterpts = 8;
    public Transform Camera;
    public GameObject CongratsMessage;
    public bool PlayerGround = true;
    public Rigidbody rb;
    public bool pickGun = false;
    public Transform head;
    public GameObject PlayerGun;
    bool mouseClick = false;
    bool sprint;
    public Image staminaBar;
    public bool iWanDie = false;
    public bool pause = false;
    public GameObject CrossHair;
    public int Count = 0;
    public bool keyboss = false;
    public AudioSource CollectAudio;
    public bool Key = false;
    PlayerHealth script;


    void Start()
    {
        script = FindObjectOfType<PlayerHealth>();
    }



      public void OnCollisionEnter(Collision collision)
      {
        
         if (collision.gameObject.tag == "ground")
          {
              PlayerGround = true;
          }

          else if (collision.gameObject.tag == "tele")
          {
              SceneManager.LoadScene(2);
          }
          else if (collision.gameObject.tag == "tele2")
          {
              SceneManager.LoadScene(3);
          }
          else if (collision.gameObject.tag == "tele3")
          {
              SceneManager.LoadScene(3);
          }

          else if (collision.gameObject.tag == "tele4")
          {
              SceneManager.LoadScene(4);
          }
      } 
      public void OnCollisionStay(Collision collision)
      {
          if (collision.gameObject.tag == "Collectables")
          {
              Debug.Log("Stay :" + collision.gameObject.name);
          }

      }

      public void OnCollisionExit(Collision collision)
      {
          if (collision.gameObject.tag == "Collectables")
          {
              Debug.Log("Exit :" + collision.gameObject.name);
          }

      }

    void OnFire()
    {
        //SceneManager.LoadScene(1);
        mouseClick = true;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnLook(InputValue value)
    {
        rotationInput.y = value.Get<Vector2>().x;
        rotationInput.x = -value.Get<Vector2>().y;
    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void OnSprintStart()
    {
        sprint = true;

    }
    void OnSprintFinish()
    {
        sprint = false;
    }

    void CheckHealth()
    {
        if (script.CurrentHealth <= 0)
        {
            //Debug.Log("True");
            iWanDie = true;
        }
    }
    // on space key, character can jump

    void OnSpaceKey()
    {
        if (PlayerGround == true)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            PlayerGround = false;
        }
    }


    //PlayerSpawnSpot marker = FindObjectOfType<PlayerSpawnSpot>();

    //activePlayer.transform.position = marker.transform.position;
    //activePlayer.transform.rotation = marker.transform.rotation;
    //          return;
    //      }
    //  }


    public void Update()
    {

        CheckHealth();

        if (iWanDie == true)
        {
            return;
        }

        Vector3 forwardDir = transform.forward;
        forwardDir *= movementInput.y;

        Vector3 rightDir = transform.right;
        rightDir *= movementInput.x;


        //transform.position += (forwardDir + rightDir) * movementSpeed;
        //Rotate left and right
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotationInput.y, 0) * rotationSpeed);
        //Rotate up and down
        var headRot = Camera.rotation.eulerAngles + new Vector3(rotationInput.x, 0, 0) * rotationSpeed;
        //Limitation

        Camera.rotation = Quaternion.Euler(headRot);

        if (sprint && staminaBar.fillAmount > 0)
        {
            Debug.Log("sprint");
            GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDir + rightDir) * 0.2f);
            staminaBar.fillAmount -= 0.25f * Time.deltaTime;
        }

        else if (sprint && staminaBar.fillAmount <= 0)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDir + rightDir) * movementSpeed);
        }

        else if (!sprint && staminaBar.fillAmount >= 0)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDir + rightDir) * movementSpeed);
            staminaBar.fillAmount += 0.35f * Time.deltaTime;
        }
        
        
        Debug.DrawLine(transform.position, head.transform.position + (head.transform.forward));


        RaycastHit hitInfo;
        if (Physics.Raycast(head.transform.position, head.transform.forward, out hitInfo, 10f))
        {
            if (hitInfo.transform.tag == "gun" && mouseClick)
            {
                PlayerGun.SetActive(true);
                CrossHair.SetActive(true);
            }
            else if (hitInfo.transform.tag == "tele" && mouseClick)
            {
                SceneManager.LoadScene(2);
            }
            else if (hitInfo.transform.tag == "Gen" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
            }
            else if (hitInfo.transform.tag == "Reactor" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
            }
            else if (hitInfo.transform.tag == "Sphere" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
            }
            else if (hitInfo.transform.tag == "HealthGen" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
            }

            else if (hitInfo.transform.tag == "Balls" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
            }

            else if (hitInfo.transform.tag == "KeyOne" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
            }

            else if (hitInfo.transform.tag == "KeyTwo" && mouseClick)
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                keyboss = true;
                Count += 1;
            }
            else if (hitInfo.transform.tag == "Button" && mouseClick)
            {
                hitInfo.transform.GetComponent<Button>().ButtonClicked();
            }
            else if (hitInfo.transform.tag == "FinalBoss" && mouseClick)
            {
                hitInfo.transform.GetComponent<BossKey>().UnlockBoss();
            }
  
            else if (hitInfo.transform.tag == "Treasure" && mouseClick)
            {
                hitInfo.transform.GetComponent<Button>().TreasureDoor();
            }
            else if (hitInfo.transform.tag == "gate" && mouseClick)
            {
                Key = true;
                hitInfo.transform.GetComponent<unlock>().UnlockGate();
            }
            else if (hitInfo.transform.tag == "Tele5" && mouseClick)
            {
                
            }

            mouseClick = false;
        }

    }
}