using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Animator _animator;
    public float Health = 3; // { get; private set; } = 3;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0) Death();
    }
    public void Death()
    {
        _animator.SetBool("Dead", true);
        //Destroy(gameObject);
    }
}
