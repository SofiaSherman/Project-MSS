using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent), typeof(EnemyManager))]
abstract public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected ScoreManager _scoreManager;
    protected Transform _target;
    protected NavMeshAgent _agent;
    protected EnemyManager _enemyManager;
    protected Animator _animator;
    protected ParticleSpawner _particleSpawner;
    protected AudioManager _audioManager;
    
    protected float attackDamage;

    private void Awake()
    {
        PlayerManager temp = (PlayerManager)FindAnyObjectByType(typeof(PlayerManager));
        _target = temp.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _enemyManager = GetComponent<EnemyManager>();
        _particleSpawner = GameObject.FindWithTag("GameManager").GetComponent<ParticleSpawner>();
        _scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }
    protected virtual void Start()
    {
        //base script from where behaviors inherit, basics here and setting up for the children scripts
        attackDamage = 1;
        
    }

    protected virtual void OnEnable()
    {
        //on enabling the script, speed is changed depending on the enemy behavior and speed from the manager
        _agent.speed = _enemyManager.speed;
    }
}
