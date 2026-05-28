using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private PlayerManager p_manager;
    private Animator _animator;

    [SerializeField] private float maxHealth = 10f;
    public float health;
    public bool isDead = false;

    [Header("Death Settings")]
    [SerializeField] private int deathSceneIndex; // Scene build index

    private void Start()
    {
        p_manager = GetComponent<PlayerManager>();
        _animator = GetComponent<Animator>();
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;

            if (p_manager != null)
            {
                StartCoroutine(StartDeathSequence());
            }

            // Load scene by build index
           
        }
    }

    private IEnumerator StartDeathSequence()
    {
        isDead  = true;
        _animator.SetBool("Dead", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(deathSceneIndex);
    }
}