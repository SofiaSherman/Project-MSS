using System.Collections;
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

    private IEnumerator Attack()
    {
        while (_agent.remainingDistance < _enemyManager.attackDistance)
        {
            Debug.Log("attacking");

            Collider[] results = Physics.OverlapSphere(attackPoint.transform.position, 1);
            foreach (Collider result in results)
            {
                if (result.gameObject.TryGetComponent(out IDamageable playerdamage) && result.gameObject.tag != "Player")
                {
                    Debug.Log(result);
                    playerdamage.TakeDamage(attackDamage);
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
