using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private PlayerManager p_manager;

    [SerializeField] private float maxHealth = 10f;
    public float health;

    [Header("Death Settings")]
    [SerializeField] private int deathSceneIndex; // Scene build index

    private void Start()
    {
        p_manager = GetComponent<PlayerManager>();
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
                SceneManager.LoadScene(deathSceneIndex);
            }

            // Load scene by build index
           
        }
    }
}