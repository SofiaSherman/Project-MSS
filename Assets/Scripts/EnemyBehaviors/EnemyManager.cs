using UnityEngine;

public enum EnemyStates
{
    Chasing,
    Attacking,
    Death
}
[RequireComponent(typeof(EnemyAttack), typeof(EnemyDeath), typeof(ChaseScript))]
[RequireComponent(typeof (EnemyHealth))]

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    private Transform _target;
    public float speed { get; private set; } = 10;

    [SerializeField] public EnemyStates enemyState;
    [SerializeField] public EnemyBase[] enemyStates;
    [SerializeField] public float attackDistance;

    private EnemyHealth enemyHealth;

    public void Start()
    {
        _target = FindAnyObjectByType<PlayerManager>().transform;
        enemyHealth = GetComponent<EnemyHealth>();
        ChangeState(EnemyStates.Chasing);
        enemyHealth.maxHealth = 10;
        enemyHealth.currentHealth = 10;
        
        _audioManager = _audioManager.GetComponent<AudioManager>();
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

    public void ChangeState(EnemyStates newState)
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
        if (AttackRange(attackDistance)) return;

        speed = 5;
        _audioManager.PlayRandomZombieSound();
        ChangeState(EnemyStates.Chasing);
        
    }
    private void UpdateChase()
    {
        if (!AttackRange(attackDistance) && enemyHealth.currentHealth > 0) return;
        speed = 0;
        ChangeState(EnemyStates.Attacking);

        if (enemyHealth.currentHealth > 0) return;
        speed = 0;
        ChangeState(EnemyStates.Death);
    }

    private bool AttackRange(float attackRange)
    {
        if(!_target) return false;
        var sqrDistance = (_target.position - transform.position).sqrMagnitude;
        return sqrDistance <= Mathf.Pow(attackRange, 1);
    }

    public void ReceiveDamage(float damage)
    {
        if(enemyHealth.currentHealth <= 0)
        {
            UpdateChase();
        }
        else
        {
            enemyHealth.currentHealth -= damage;
        }
    }
}
