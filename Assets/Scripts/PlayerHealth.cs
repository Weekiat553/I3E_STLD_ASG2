using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    public HealthBar HealthBar;
    public float healing;
    public float ballDamage;
    public bool death = false;
    public UnityEvent unityEvent = new UnityEvent();
    [SerializeField] public float CurrentHealth;
    public AudioSource DamageSound;
    public AudioSource DeathSound;
    public AudioSource HealSound;
    Respawn script;

    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        script = FindObjectOfType<Respawn>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Heal")
        {
            if (CurrentHealth == MaxHealth)
            {
                return;
            }
            else if (CurrentHealth < MaxHealth)
            {
                HealSound.Play();
                CurrentHealth += healing;
                HealthBar.SetHealth(CurrentHealth);
                Destroy(collision.gameObject);
            }
        }
    }

        public void TakeDamage(float Amount)
    {
        CurrentHealth -= Amount;
        DamageSound.Play();
        HealthBar.SetHealth(CurrentHealth);
        if(CurrentHealth <= 0)
        {
            Debug.Log("Player died");
            DeathSound.Play();
            death = true;
            unityEvent.Invoke();
        }

    }
    
    void Update()
    {

    }

}
