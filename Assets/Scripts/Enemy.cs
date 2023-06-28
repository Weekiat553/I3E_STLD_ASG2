using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float MaxHealth;
    public float MaxSpeed;
    private float Speed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRange;

    public Rigidbody rb;
    public GameObject Target;

    private bool seePlayer;

    public float Damage;
    public float DamageTime;

    private bool CanAttack = true;
    public bool iWanDie = false;

    public float CurrentHealth;
    public HealthBar HealthBar;

    void Start()
    {
        Speed = MaxSpeed;
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }
    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        HealthBar.SetHealth(CurrentHealth);
        if (CurrentHealth <= 0f)
        {
            //Die Animation
            GetComponent<Animator>().SetTrigger("EDeathTrigger");
            iWanDie = true;
            Die();
            
        }
    }

    void Die()
    {   
        Destroy(gameObject, 3);
    }

    void Update()
    {
        
        //Detect player in range
        if (iWanDie == true)
        {
            return;
        }

        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {
                if(HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;

                }
            }
        }
        else
        {
            if(Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if (Hit.collider.tag != "Player")
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
        if(collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            StartCoroutine(AttackDelay(DamageTime));
        }
    }

    //Attack delay

    public IEnumerator AttackDelay(float Delay)
    {
        Speed = 0;
        CanAttack = false;
        yield return new WaitForSeconds(Delay);
        Speed = MaxSpeed;
        CanAttack = true;
    }
}
