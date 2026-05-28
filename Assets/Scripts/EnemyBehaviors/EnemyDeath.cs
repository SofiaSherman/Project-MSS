using TMPro;
using UnityEngine;

public class EnemyDeath : EnemyBase
{
    
    [SerializeField] private int scoreOnDeath;

    private EnemyAttack _enemyAttack;

    private bool hasExplodedOnce = false;
    protected override void Start()
    {
        base.Start();
        _enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Update()
    {
    }
    private void Dying()
    {
        Debug.Log("normal death");
        _scoreManager.score += scoreOnDeath;
        _scoreManager.scoreText.text = "Score: " + _scoreManager.score.ToString();
        
        _animator.SetTrigger("Death");
        Debug.Log("animation trigger play");
        Destroy(gameObject,2);
    }

    private void ExplosionZombieDying()
    {
        Debug.Log("explosion death");
        
        _audioManager.PlaySound("dynamiteExplosion");
        _particleSpawner.SpawnExplosionParticle(this.gameObject);
        Destroy(gameObject,0.2f);
    }

    protected override void OnEnable()
    {
        Debug.Log("OnEnable");
        base.OnEnable();

        if (_enemyManager.isExploder && !hasExplodedOnce)
        {
            hasExplodedOnce = true;
            ExplosionZombieDying();
            _agent.speed = _enemyManager.speed;
        }
        
        Dying();
        _agent.speed = _enemyManager.speed;
    }
}
