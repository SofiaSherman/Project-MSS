using UnityEngine;

public class EnemyDeath : EnemyBase
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        Dying();
    }
    private void Dying()
    {
        Destroy(gameObject);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _agent.speed = _enemyManager.speed;
    }
}
