using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 10;
    public float currentHealth;

    private void Start()
    {
        maxHealth = currentHealth;
    }
    public void TakeDamage(float damage)
    {

        if (currentHealth <= 0)
        {
            
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
