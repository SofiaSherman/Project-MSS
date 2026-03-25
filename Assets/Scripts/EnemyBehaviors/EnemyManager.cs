using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    public void Start()
    {
        maxHealth = 10;
        currentHealth = 10;
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void ReceiveDamage(float damage)
    {
        if(currentHealth <= 0)
        {
            Death();
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
