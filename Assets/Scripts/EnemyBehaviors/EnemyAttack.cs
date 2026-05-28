using System.Collections;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float attackRadius = 2f;
    [SerializeField] private float explosionAttackRadius = 15f;
    [SerializeField] private float explosionDamage = 2f;
    [SerializeField] private float enemyDamage;
    
    public bool hasExploded = false;
    private bool hasExplodedOnce = false;

    private float attackSpeed;
    
    protected override void Start()
    {
        base.Start();
        attackSpeed = 3f;

        if (_enemyManager.isExploder)
        {
            attackRadius = explosionAttackRadius;
            attackDamage = explosionDamage;
        }
        else
        {
            attackDamage = enemyDamage;
        }
        
    }

    private IEnumerator Attack()
    {
        while (_agent.remainingDistance < _enemyManager.attackDistance)
        {
            
            if (!_enemyManager.isExploder)
            {
                _animator.SetTrigger("Attack");
            }
            else
            {
                _animator.SetTrigger("Explode");
                yield return new WaitForSeconds(0.5f);
                hasExploded = true;
            }

            Collider[] results = Physics.OverlapSphere(attackPoint.transform.position, attackRadius);
            foreach (Collider result in results)
            {
                if (result.gameObject.TryGetComponent(out IDamageable playerdamage) && result.gameObject.tag == "Player")
                {
                    if ((_enemyManager.isExploder && !hasExplodedOnce) || (!_enemyManager.isExploder))
                    {
                        hasExplodedOnce = true;
                        playerdamage.TakeDamage(attackDamage);
                    }
                    
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, 1);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(Attack());
        _agent.speed = _enemyManager.speed;
    }

    private void OnDisable()
    {
        StopCoroutine(Attack());
    }
}
