/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Player script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class player : MonoBehaviour
{

    Vector3 movementInput = Vector3.zero;

    /// <summary>
    /// movementSpeed
    /// </summary>
    public float movementSpeed;

    Vector3 rotationInput = Vector3.zero;

    /// <summary>
    /// Rotation speed
    /// </summary>
    public float rotationSpeed = 1f;

    /// <summary>
    /// Retrieve Camera
    /// </summary>
    public Transform Camera;


    //public GameObject CongratsMessage;

    /// <summary>
    /// Ground boolean
    /// </summary>
    public bool PlayerGround = true;

    /// <summary>
    /// Player rigidbody
    /// </summary>
    public Rigidbody rb;

    /// <summary>
    /// Gun pick boolean
    /// </summary>
    public bool pickGun = false;

    /// <summary>
    /// Retrieve camera
    /// </summary>
    public Transform head;

    /// <summary>
    /// Store player gun
    /// </summary>
    public GameObject PlayerGun;

    /// <summary>
    /// On mouse down boolean
    /// </summary>
    bool mouseClick = false;

    /// <summary>
    /// Sprint boolean
    /// </summary>
    bool sprint;

    /// <summary>
    /// Access image 
    /// </summary>
    public Image staminaBar;

    /// <summary>
    /// When die movement boolean
    /// </summary>
    public bool iWanDie = false;

    /// <summary>
    /// Pause boolean
    /// </summary>
    public bool pause = false;

    /// <summary>
    /// Store crosshair
    /// </summary>
    public GameObject CrossHair;

    /// <summary>
    /// Count item
    /// </summary>
    public int Count = 0;

    /// <summary>
    /// Boss key boolean
    /// </summary>
    public bool keyboss = false;

    /// <summary>
    /// Collect sound audio
    /// </summary>
    public AudioSource CollectAudio;

    /// <summary>
    /// boolean key
    /// </summary>
    public bool Key = false;

    /// <summary>
    /// Access player script
    /// </summary>
    //PlayerHealth script;

    /// <summary>
    /// Set Max health
    /// </summary>
    public float MaxHealth;

    /// <summary>
    /// Access healthbar
    /// </summary>
    public HealthBar HealthBar;

    /// <summary>
    /// Set healing float
    /// </summary>
    public float healing;

    /// <summary>
    /// Set ball damage float
    /// </summary>
    public float ballDamage;

    /// <summary>
    /// death boolean
    /// </summary>
    public bool death = false;

    /// <summary>
    /// Unity Event
    /// </summary>
    public UnityEvent unityEvent = new UnityEvent();

    /// <summary>
    /// Set current health
    /// </summary>
    [SerializeField] public float CurrentHealth;

    /// <summary>
    /// Access Damage sound
    /// </summary>
    public AudioSource DamageSound;

    /// <summary>
    /// Access death sound
    /// </summary>
    public AudioSource DeathSound;

    /// <summary>
    /// Access heal sound
    /// </summary>
    public AudioSource HealSound;

    /// <summary>
    /// Generator boolean
    /// </summary>
    public bool GenBool = false;

    /// <summary>
    /// Health boolean
    /// </summary>
    public bool HealthBool = false;

    /// <summary>
    /// Sphere boolean
    /// </summary>
    public bool SphereBool = false;

    /// <summary>
    /// Reactor boolean
    /// </summary>
    public bool ReactorBool = false;

    /// <summary>
    /// store sphere ui
    /// </summary>
    public GameObject SphereUi;

    /// <summary>
    /// store health ui
    /// </summary>
    public GameObject HealthUi;

    /// <summary>
    /// Store generator ui
    /// </summary>
    public GameObject GenUi;

    /// <summary>
    /// store reactor ui
    /// </summary>
    public GameObject ReactorUi;

    /// <summary>
    /// store balls ui
    /// </summary>
    public GameObject BallsUi;

    /// <summary>
    /// Count fixed item 
    /// </summary>
    public int FixCount = 0;

    /// <summary>
    /// Access respawn script
    /// </summary>
    Respawn rscript;

    /// <summary>
    /// Access show script
    /// </summary>
    Show sscript;

    /// <summary>
    /// Run on the start
    /// </summary>
    void Start()
    {
       // script = FindObjectOfType<PlayerHealth>(); //Store playerhealth script
        CurrentHealth = MaxHealth; // set current health to maxhealth
        HealthBar.SetMaxHealth(MaxHealth); // Link to healthbar
        rscript = FindObjectOfType<Respawn>(); // store respawn script
        sscript = FindObjectOfType<Show>(); // store show script
    }


    /// <summary>
    /// Collide with healing item
    /// </summary>
    public void OnCollisionEnter(Collision collision)
      {
        if (collision.gameObject.tag == "Heal") // if tag is heal
        {
            if (CurrentHealth == MaxHealth) //if current health is full
            {
                return;
            }
            else if (CurrentHealth < MaxHealth) // if less than max health
            {
                HealSound.Play(); // play heal sound
                CurrentHealth += healing; // add on health
                HealthBar.SetHealth(CurrentHealth); // link to health bar
                Destroy(collision.gameObject); // destroy object
            }
        }

        if (collision.gameObject.tag == "ground") // when collide with ground
          {
              PlayerGround = true; 
          }

          else if (collision.gameObject.tag == "tele") // when collide with tele
          {
              SceneManager.LoadScene(2); // go to scene 2
          }
          else if (collision.gameObject.tag == "tele2") // when collide with tele2
          {
              SceneManager.LoadScene(3); // go to scene 3
          }
          else if (collision.gameObject.tag == "tele3") // when collide with tele3
          {
              SceneManager.LoadScene(3); // go to scebe 3
          }

          else if (collision.gameObject.tag == "tele4") // when collide with tele 4
          {
              SceneManager.LoadScene(4); // go to scene 4
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
    /// <summary>
    /// Run dmamage taken function
    /// </summary>
    public void TakeDamage(float Amount)
    {
        CurrentHealth -= Amount; // reduce current health
        DamageSound.Play(); // play damage sound
        HealthBar.SetHealth(CurrentHealth); // link healthbar
        if (CurrentHealth <= 0) //if current health less than or = 0
        {
            //Debug.Log("Player died");
            DeathSound.Play(); // play death sound
            death = true; 
            unityEvent.Invoke(); // unity event
        }

    }
    /// <summary>
    /// Mouse down function
    /// </summary>
    void OnFire()
    {
        //SceneManager.LoadScene(1);
        mouseClick = true; 
    }

    /// <summary>
    /// Run before start function
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// OnLook function
    /// </summary>
    void OnLook(InputValue value)
    {
        rotationInput.y = value.Get<Vector2>().x;
        rotationInput.x = -value.Get<Vector2>().y;
    }

    /// <summary>
    /// On move function
    /// </summary>
    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    /// <summary>
    /// Sprint is hold down function
    /// </summary>
    void OnSprintStart()
    {
        sprint = true;

    }
    /// <summary>
    /// Sprint is release function
    /// </summary>
    void OnSprintFinish()
    {
        sprint = false;
    }
    /// <summary>
    /// Check player health function
    /// </summary>
    void CheckHealth()
    {
        if (CurrentHealth <= 0) // if current health is less than 0 or = 0
        {
            //Debug.Log("True");
            iWanDie = true;
        }
    }
    // on space key, character can jump

    /// <summary>
    /// Jump function
    /// </summary>
    void OnSpaceKey()
    {
        if (PlayerGround == true) // if playerground is true
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse); // jump
            PlayerGround = false;
        }
    }




    /// <summary>
    /// Run on update
    /// </summary>
    public void Update()
    {

        CheckHealth(); // run check health function

        if (iWanDie == true) // stop player movmenet
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
            //Debug.Log("sprint");
            GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDir + rightDir) * 0.2f);  // Player sprint
            staminaBar.fillAmount -= 0.25f * Time.deltaTime;
        }

        else if (sprint && staminaBar.fillAmount <= 0)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDir + rightDir) * movementSpeed); // player walk
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
            if (hitInfo.transform.tag == "gun" && mouseClick) // if gun tag is detected
            {
                PlayerGun.SetActive(true);
                CrossHair.SetActive(true);
            }
            else if (hitInfo.transform.tag == "tele" && mouseClick) // when tele tag is detected
            {
                SceneManager.LoadScene(2);
            }
            else if (hitInfo.transform.tag == "Gen" && mouseClick) // when gen tag is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
                GenUi.SetActive(true);
                GenBool = true;
            }
            else if (hitInfo.transform.tag == "Reactor" && mouseClick) // when reactor tag is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
                ReactorUi.SetActive(true);
                ReactorBool = true;
            }
            else if (hitInfo.transform.tag == "Sphere" && mouseClick) // when sphere tag is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
                SphereBool = true;
                SphereUi.SetActive(true);
            }
            else if (hitInfo.transform.tag == "Healthgen" && mouseClick) // when healthgen tag is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                Count += 1;
                HealthBool = true;
                HealthUi.SetActive(true);
            }

            else if (hitInfo.transform.tag == "Balls" && mouseClick) // when balls is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                BallsUi.SetActive(true);
            }

            else if (hitInfo.transform.tag == "KeyOne" && mouseClick) // when keyone is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
            }

            else if (hitInfo.transform.tag == "KeyTwo" && mouseClick) // when keytwo is detected
            {
                CollectAudio.Play();
                hitInfo.transform.GetComponent<Destroy>().DestroyItem();
                keyboss = true;
                Count += 1;
            }

            else if (hitInfo.transform.tag == "Button" && mouseClick) // when button is detected
            {
                hitInfo.transform.GetComponent<Button>().ButtonClicked();
            }

            else if (hitInfo.transform.tag == "FinalBoss" && mouseClick) // when finalboss is detected
            {
                hitInfo.transform.GetComponent<BossKey>().UnlockBoss();
            }
  
            else if (hitInfo.transform.tag == "Treasure" && mouseClick) // when treasure is detected
            {
                hitInfo.transform.GetComponent<Button>().TreasureDoor();
            }

            else if (hitInfo.transform.tag == "gate" && mouseClick) // when gate is detected
            {
                Key = true;
                hitInfo.transform.GetComponent<unlock>().UnlockGate();
            }

            else if (hitInfo.transform.tag == "Tele5" && mouseClick)
            {
                SceneManager.LoadScene(1);
            }

            else if (hitInfo.transform.tag == "FixSphere" && mouseClick) // when fixsphere is detected
            {
                if(SphereBool == true)
                {
                    hitInfo.transform.GetComponent<Show>().ShowSphere();
                    //SphereBool = true;
                    FixCount += 1;
                }
                
            }

            else if (hitInfo.transform.tag == "FixGen" && mouseClick) // when fixGen is detected
            {
                if (GenBool == true)
                {
                    hitInfo.transform.GetComponent<Show>().ShowGen();
                    //GenBool = true;
                    FixCount += 1;
                }
                
            }

            else if (hitInfo.transform.tag == "FixHealth" && mouseClick) // when fixhealth is detected
            {
                if(HealthBool == true)
                {
                    //HealthBool = true;
                    hitInfo.transform.GetComponent<Show>().ShowHealth();
                    FixCount += 1;
                }
            
            }

            else if (hitInfo.transform.tag == "FixReactor" && mouseClick) // when fixreactor is detected
            {
                //ReactorBool = true;
                if(ReactorBool == true)
                {
                    hitInfo.transform.GetComponent<Show>().ShowReactor();
                    FixCount += 1;
                }
                
            }

            else if (hitInfo.transform.tag == "Panel"  && mouseClick) // when panel is detected
            {

                Debug.Log(FixCount);
                if (FixCount >= 4)
                {
                    SceneManager.LoadScene(5);
                    gameObject.SetActive(false);
                }
            }

            mouseClick = false; 
        }

    }
}