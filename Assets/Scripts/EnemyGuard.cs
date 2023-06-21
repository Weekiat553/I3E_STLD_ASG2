using UnityEngine;

public class EnemyGuard : MonoBehaviour
{
    public float health = 50f;
    public GameObject GuardKey;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            //Die Animation
            GetComponent<Animator>().SetTrigger("EDeathTrigger");
            //GuardKey.SetActive(true);
            Die();

        }
    }

    void Die()
    {
        Destroy(gameObject, 3);
        
    }
}
