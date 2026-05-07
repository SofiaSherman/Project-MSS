using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

    private PlayerManager p_manager;

    private float maxHealth = 10;
    public float health = 3;

    private void Start()
    {
        p_manager = GetComponent<PlayerManager>();
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0) p_manager.Death();
        health -= damage;
    }
}
