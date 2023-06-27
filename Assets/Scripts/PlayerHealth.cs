using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    public HealthBar HealthBar;
    public float healing;
    [SerializeField] public float CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
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
                CurrentHealth += healing;
                HealthBar.SetHealth(CurrentHealth);
                Destroy(collision.gameObject);
            }
        }
    }

        public void TakeDamage(float Amount)
    {
        CurrentHealth -= Amount;
        HealthBar.SetHealth(CurrentHealth);
        if(CurrentHealth <= 0)
        {
            Debug.Log("Player died");
        }



    }

}
