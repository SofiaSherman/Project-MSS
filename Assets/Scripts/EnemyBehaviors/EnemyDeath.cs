using UnityEngine;

public class EnemyDeath : EnemyBase
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
       
    }
    private void Dying()
    {
        Destroy(gameObject,2);
        _animator.SetTrigger("Death");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Dying();
        _agent.speed = _enemyManager.speed;
    }
}
