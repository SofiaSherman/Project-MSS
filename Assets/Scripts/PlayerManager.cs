using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float Health { get; private set; } = 3;
    private void Start()
    {
        
    }


    public void TakeDamage(float damage)
    {
        if(Health <= 0) Death();
        Health -= damage;
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
