using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHealth = 10;
    public float currentHealth;

    private EnemyManager manager;

    private void Start()
    {
        manager = GetComponent<EnemyManager>();
        maxHealth = currentHealth;
    }
    public void TakeDamage(float damage)
    {

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
