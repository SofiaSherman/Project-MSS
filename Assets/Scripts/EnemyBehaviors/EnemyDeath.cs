using TMPro;
using UnityEngine;

public class EnemyDeath : EnemyBase
{
    
    [SerializeField] private AudioManager _audioManager;
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
        _scoreManager.scoreText.text = "Score: " + _scoreManager.score.ToString();
    }

    private void ExplosionZombieDying()
    {
        Destroy(gameObject,0.2f);
        _audioManager.PlaySound("dynamiteExplosion");
        _particleSpawner.SpawnExplosionParticle(this.gameObject);
    }

    protected override void OnEnable()
    {
        Debug.Log("OnEnable");
        base.OnEnable();

        if (this.gameObject.CompareTag("ExplodingZombie"))
        {
            ExplosionZombieDying();
            _agent.speed = _enemyManager.speed;
        }
        
        Dying();
        _agent.speed = _enemyManager.speed;
    }
}
