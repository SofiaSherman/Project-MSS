using TMPro;
using UnityEngine;

public class EnemyDeath : EnemyBase
{
    
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private int scoreOnDeath;

    private EnemyAttack _enemyAttack;

    protected override void Start()
    {
        base.Start();
        _enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Update()
    {
        if (_enemyAttack.hasExploded)
        {
            ExplosionZombieDying();
        }
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
        //_scoreManager.score += scoreOnDeath;
        //_scoreManager.scoreText.text = "Score: " + _scoreManager.score.ToString();
        
        Destroy(gameObject,0.2f);
        _audioManager.PlaySound("dynamiteExplosion");
        _particleSpawner.SpawnExplosionParticle(this.gameObject);
    }

    protected override void OnEnable()
    {
        Debug.Log("OnEnable");
        base.OnEnable();

        if (_enemyManager.isExploder)
        {
            ExplosionZombieDying();
            _agent.speed = _enemyManager.speed;
        }
        
        Dying();
        _agent.speed = _enemyManager.speed;
    }
}
