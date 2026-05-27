using System.Collections;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    [SerializeField] private GameObject attackPoint;

    private float attackSpeed;
    
    private EnemyExplode _enemyExplode;
    protected override void Start()
    {
        base.Start();
        attackSpeed = 3f;

        if (this.gameObject.GetComponent<EnemyExplode>() != null)
        {
            _enemyExplode = GetComponent<EnemyExplode>();
        }
    }

    private IEnumerator Attack()
    {
        Debug.Log("Tried attacking");
        while (_agent.remainingDistance < _enemyManager.attackDistance)
        {
            Debug.Log("attacking");
            _animator.SetTrigger("Attack");

            Collider[] results = Physics.OverlapSphere(attackPoint.transform.position, 1);
            foreach (Collider result in results)
            {
                if (result.gameObject.TryGetComponent(out IDamageable playerdamage) && result.gameObject.tag != "Player")
                {
                    Debug.Log(result);
                    playerdamage.TakeDamage(attackDamage);
                    /*if (this.gameObject.CompareTag("ExplodingZombie"))
                    {
                        _enemyExplode.Explode();
                    }
                    else
                    {
                    }*/
                }
            }
            yield return new WaitForSeconds(3);
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
