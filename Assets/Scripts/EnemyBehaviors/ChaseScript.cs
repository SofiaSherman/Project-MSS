using UnityEngine;
using UnityEngine.AI;

public class ChaseScript : EnemyBase
{
    [SerializeField] private float enemySpeed;

    private float counter;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        counter += Time.deltaTime;
        TargetDestination();
    }

    private void TargetDestination()
    {
        if (counter >= 0.2f)
        {
            transform.LookAt(_target.position);
            _agent.SetDestination(_target.position);
            counter = 0;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        
    }
}
