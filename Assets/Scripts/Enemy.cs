/*
 * Author: Wee Kiat
 * Date: 7/2/2023
 * Description: Enemy attack player and health script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Enemy Maxhealth
    /// </summary>
    public float MaxHealth;

    /// <summary>
    /// Enemy MaxSpeed
    /// </summary>
    public float MaxSpeed;

    /// <summary>
    /// Enemy current speed
    /// </summary>
    private float Speed;

    /// <summary>
    /// Collide
    /// </summary>
    private Collider[] hitColliders;

    /// <summary>
    /// Raycast "hit"
    /// </summary>
    private RaycastHit Hit;

    /// <summary>
    /// Enemy sight range
    /// </summary>
    public float SightRange;

    /// <summary>
    /// Enemy detect player range
    /// </summary>
    public float DetectionRange;

    /// <summary>
    /// Enemy Rigidbody
    /// </summary>
    public Rigidbody rb;

    /// <summary>
    /// Enemy Target
    /// </summary>
    public GameObject Target;

    /// <summary>
    /// Boolean to identify player
    /// </summary>
    private bool seePlayer;

    /// <summary>
    /// Enemy Damage
    /// </summary>
    public float Damage;

    /// <summary>
    /// Enemy buffer time damage
    /// </summary>
    public float DamageTime;

    /// <summary>
    /// Enemy can attack player boolean
    /// </summary>
    private bool CanAttack = true;

    /// <summary>
    /// Enemy Maxhealth
    /// </summary>
    public bool iWanDie = false;

    /// <summary>
    ///Enemy boolean dead
    /// </summary>
    public bool ded = false;

    /// <summary>
    /// Enemy CurrentHealth
    /// </summary>
    public float CurrentHealth;

    /// <summary>
    /// Links to healthbar
    /// </summary>
    public HealthBar HealthBar;

    /// <summary>
    /// Run the following code at the start
    /// </summary>
    void Start()
    {
        Speed = MaxSpeed; // Set current speed to max speed value
        CurrentHealth = MaxHealth; // Set currenthealth value to max health value
        HealthBar.SetMaxHealth(MaxHealth); // Retrieve to Healthbar script Maxhealth
    }

    /// <summary>
    /// Enemy taking damage
    /// </summary>
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount; //Minus health from the bullets shot by the plaer
        HealthBar.SetHealth(CurrentHealth); // Links Currenthealth to the slider of the healthbar
        if (CurrentHealth <= 0f) // if currenthealth is less than or 0
        {
            GetComponent<Animator>().SetTrigger("EDeathTrigger"); // trigger death animation
            iWanDie = true; //Stop enemy from moving
            ded = true;
            Die(); // Run the function die 
            
        }
    }

    void Die()
    {   
        Destroy(gameObject, 3); //Destroy the gameobject after 3 seconds
    }

    void Update()
    {
        
        //Detect player in range
        if (iWanDie == true) // if iwantdie is true capsule to stop moving
        {
            return;
        }

        if (!seePlayer) //See player
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {
                if(HitCollider.tag == "Player") // If collider detects player tag
                {
                    Target = HitCollider.gameObject; //Target become player
                    seePlayer = true;

                }
            }
        }
        else
        {
            if(Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if (Hit.collider.tag != "Player") // If collider does not detect player
                {
                    seePlayer = false;
                }
                else
                {
                    // calculate the directions

                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;

                    Vector3 Move = new Vector3(Direction.x * Speed,0,Direction.z * Speed);
                    rb.velocity = Move;
                    transform.forward = Move;
                   
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")  // If touch player
        {
            collision.gameObject.GetComponent<player>().TakeDamage(Damage); //Lower players health
            StartCoroutine(AttackDelay(DamageTime)); // Delay attack time
        }
    }

    //Attack delay

    public IEnumerator AttackDelay(float Delay) //Delay attack 
    {
        Speed = 0;
        CanAttack = false;
        yield return new WaitForSeconds(Delay);
        Speed = MaxSpeed;
        CanAttack = true;
    }
}
