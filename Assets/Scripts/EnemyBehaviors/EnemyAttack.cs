using System.Collections;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float checkAttackRadius;
    
    public bool hasExploded = false;

    private float attackSpeed;
    
    protected override void Start()
    {
        base.Start();
        attackSpeed = 3f;
        
    }

    private IEnumerator Attack()
    {
        Debug.Log("Tried attacking");
        while (_agent.remainingDistance < _enemyManager.attackDistance)
        {
            Debug.Log("attacking");
            
            if (!this.gameObject.CompareTag("ExplodingZombie"))
            {
                _animator.SetTrigger("Attack");
            }
            else
            {
                Debug.Log("call explosion");
                _animator.SetTrigger("Explode");
                yield return new WaitForSeconds(0.5f);
                hasExploded = true;
            }

            Collider[] results = Physics.OverlapSphere(attackPoint.transform.position, checkAttackRadius);
            foreach (Collider result in results)
            {
                if (result.gameObject.TryGetComponent(out IDamageable playerdamage) && result.gameObject.tag == "Player")
                {
                    
                    playerdamage.TakeDamage(attackDamage);
                    
                    Debug.Log(result);
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
