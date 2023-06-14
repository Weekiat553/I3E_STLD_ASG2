using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    //Movement speed
    Vector3 movementInput = Vector3.zero;
    public float movementSpeed = 0.05f;
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
    public TextMeshProUGUI displayText;
    public Transform Camera;
    public GameObject CongratsMessage;
    public bool PlayerGround = true;
    public Rigidbody rb;
    public bool iWanDie = false;
    public bool pickGun = false;
    public GameObject GunOnPlayer;
    public GameObject Gun;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectables")
        {
            Destroy(collision.gameObject);
            score += pts;
            var disp = score;
            displayText.text = "Score: " + disp;
        }
        else if (collision.gameObject.tag == "die")
        {
            GetComponent<Animator>().SetTrigger("Die");
            iWanDie = true;

        }
        else if (collision.gameObject.tag == "Donttouch")
        {
            score -= 1;
            displayText.text = "Score: " + score;
        }
        else if (collision.gameObject.tag == "Helmet")
        {
            score += helmetpts;
            displayText.text = "Score: " + score;
        }
        else if (collision.gameObject.tag == "Card")
        {
            score += cardpts;
            displayText.text = "Score: " + score;
        }
        else if (collision.gameObject.tag == "Gun")
        {
            score += gunpts;
            displayText.text = "Score: " + score;
        }
        else if (collision.gameObject.tag == "Sword")
        {
            score += swordpts;
            displayText.text = "Score: " + score;
            displayText.text = "Final score: ";
        }
        else if (collision.gameObject.tag == "Scouter")
        {
            score += scouterpts;
            displayText.text = "Score: " + score;
        }
        else if (collision.gameObject.tag == "ground")
        {
            PlayerGround = true;
        }

        else if (collision.gameObject.tag == "tele")
        {
            SceneManager.LoadScene(1);
        }

        else if (collision.gameObject.tag == "tele2")
        {
            SceneManager.LoadScene(2);
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


    // on space key, character can jump


    void OnEkey()
    {
       
    }

    void OnSpaceKey()
    {
        if (PlayerGround == true)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            PlayerGround = false;
        }
    }

    //   void SpawnPlayerOnLoad(Scene prev, Scene next)
    //   {
    //       Debug.Log("Entering scene is : " + next.buildIndex);
    //       if (activePlayer == null)
    //      {
    //           GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    //           activePlayer = player.GetComponent<PlayerScript>();
    //       }
    //       else
    //      {
    //PlayerSpawnSpot marker = FindObjectOfType<PlayerSpawnSpot>();

    //activePlayer.transform.position = marker.transform.position;
    //activePlayer.transform.rotation = marker.transform.rotation;
    //          return;
    //      }
    //  }


    void Update()
    {
        if (iWanDie == true)
        {
            return;
        }

        Vector3 forwardDir = transform.forward;
        forwardDir *= movementInput.y;

        Vector3 rightDir = transform.right;
        rightDir *= movementInput.x;


        transform.position += (forwardDir + rightDir) * movementSpeed;
        //Rotate left and right
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotationInput.y, 0) * rotationSpeed);
        //Rotate up and down
        var headRot = Camera.rotation.eulerAngles + new Vector3(rotationInput.x, 0, 0) * rotationSpeed;
        //Limitation

        Camera.rotation = Quaternion.Euler(headRot);
         
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if(Physics.Raycast(ray, out hit) && hit.collider.tag == "gun")
            {
                pickGun = true;
                Gun.SetActive(true);
            }


    }
}
