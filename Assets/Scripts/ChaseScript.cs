using UnityEngine;
using UnityEngine.AI;

public class ChaseScript : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;
    private float counter;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        counter += Time.deltaTime;
        TargetDestination();
    }

    private void TargetDestination()
    {
        if(counter >= 0.5f)
        {
            _agent.SetDestination(_target.position);
            counter = 0;
        } 

    }
}
