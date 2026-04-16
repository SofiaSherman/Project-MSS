using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health = 3;
    private void Start()
    {
        
    }


    public void TakeDamage(float damage)
    {
        if(health <= 0) Death();
        health -= damage;
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
