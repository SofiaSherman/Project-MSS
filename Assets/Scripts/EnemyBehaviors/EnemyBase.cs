using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent), typeof(EnemyManager))]
abstract public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected Transform _target;

    protected NavMeshAgent _agent;
    protected EnemyManager _enemyManager;

    protected float attackDamage;
    protected virtual void Start()
    {
        //base script from where behaviors inherit, basics here and setting up for the children scripts
        attackDamage = 1;
        _agent = GetComponent<NavMeshAgent>();
        _enemyManager = GetComponent<EnemyManager>();
    }

    protected virtual void OnEnable()
    {
        //on enabling the script, speed is changed depending on the enemy behavior and speed from the manager
        _agent.speed = _enemyManager.speed;
    }
}
