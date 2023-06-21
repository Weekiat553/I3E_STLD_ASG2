using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHealth;
    [SerializeField] public float CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float Amount)
    {
        CurrentHealth -= Amount;
        if(CurrentHealth <= 0)
        {
            Debug.Log("Player died");
        }



    }

}
