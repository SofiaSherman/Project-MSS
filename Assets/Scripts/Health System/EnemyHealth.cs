using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHealth = 10;
    public float currentHealth;

    private EnemyManager manager;
    
    private ParticleSpawner _particleSpawner;

    private void Start()
    {
        manager = GetComponent<EnemyManager>();
        currentHealth = maxHealth;

        _particleSpawner = GameObject.FindWithTag("GameManager").GetComponent<ParticleSpawner>();
        
    }
    public void TakeDamage(float damage)
    {
        _particleSpawner.SpawnDamageParticle(this.gameObject);
        if (currentHealth <= 0)
        {
            manager.ChangeState(EnemyStates.Death);
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
