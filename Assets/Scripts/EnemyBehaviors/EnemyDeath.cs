using UnityEngine;

public class EnemyDeath : EnemyBase
{

    [SerializeField] private int scoreOnDeath;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
       
    }
    private void Dying()
    {
        _scoreManager.score += scoreOnDeath;
        
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
