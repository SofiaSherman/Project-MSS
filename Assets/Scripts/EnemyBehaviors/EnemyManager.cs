using UnityEngine;

public enum EnemyStates
{
    Chasing,
    Attacking,
    Death
}
[RequireComponent(typeof(EnemyAttack), typeof(EnemyDeath), typeof(ChaseScript))]

public class EnemyManager : MonoBehaviour
{
    [field: SerializeField] public Transform target { get; private set; }

    public float speed { get; private set; } = 10;

    [SerializeField] public EnemyStates enemyState;
    [SerializeField] public EnemyBase[] enemyStates;
    [SerializeField] public float attackDistance;

    private float attackingRange;
    private float maxHealth;
    private float currentHealth;

    public void Start()
    {
        attackingRange = 5;
        ChangeState(EnemyStates.Chasing);
        maxHealth = 10;
        currentHealth = 10;
    }
    private void Update()
    {
        //change states on a switch case
        switch (enemyState)
        {
            case EnemyStates.Attacking:
                UpdateAttack();
                break;
            case EnemyStates.Death:
                break;
            case EnemyStates.Chasing:
                UpdateChase();
                break;
        }
    }

    private void ChangeState(EnemyStates newState)
    {
        //from the parameter, we get the state
        enemyState = newState;

        //and run the enumerator through, deactivating each state that isn't the one that coincides with the int
        //of the current index
        for (int i = 0; i < enemyStates.Length; i++)
        {
            enemyStates[i].enabled = i == (int)enemyState;
        }
    }

    private void UpdateAttack()
    {
        if (AttackRange(attackingRange)) return;

        speed = 10;
        ChangeState(EnemyStates.Chasing);
        
    }
    private void UpdateChase()
    {
        if (!AttackRange(attackingRange) && currentHealth > 0) return;
        speed = 0;
        ChangeState(EnemyStates.Attacking);

        if (currentHealth > 0) return;
        speed = 0;
        ChangeState(EnemyStates.Death);
    }

    private bool AttackRange(float attackRange)
    {
        //if(!target) return false;
        var sqrDistance = (target.position - transform.position).sqrMagnitude;
        return sqrDistance <= Mathf.Pow(attackRange, 1);
    }

    public void ReceiveDamage(float damage)
    {
        if(currentHealth <= 0)
        {
            UpdateChase();
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
