using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [SerializeField] private GameObject attackPoint;

    private float attackSpeed;
    protected override void Start()
    {
        base.Start();
        attackSpeed = 3f;
    }
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        float attackCounter = 3;
        attackCounter += Time.deltaTime;
        if (_agent.remainingDistance < _enemyManager.attackDistance)
        {
            attackCounter = 0;
            Collider[] results = Physics.OverlapSphere(attackPoint.transform.position, 1);
            foreach (Collider result in results)
            {
                if (result.gameObject.GetComponent<PlayerManager>())
                {
                    Debug.Log(result);
                    result.gameObject.GetComponent<PlayerManager>().TakeDamage(attackDamage);
                } 
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, 1);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _agent.speed = _enemyManager.speed;
    }
}
