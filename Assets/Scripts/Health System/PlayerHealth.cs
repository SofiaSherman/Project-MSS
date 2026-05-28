using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private PlayerManager p_manager;
    private Animator _animator;

    [SerializeField] public float maxHealth = 10f;
    public float health;
    public bool isDead = false;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;

    [Header("Death Settings")]
    [SerializeField] private int deathSceneIndex;

    private void Start()
    {
        p_manager = GetComponent<PlayerManager>();
        _animator = GetComponent<Animator>();

        health = maxHealth;

        // Setup slider
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        // Update UI
        healthSlider.value = health;

        if (health <= 0)
        {
            health = 0;
            healthSlider.value = health;

            if (p_manager != null)
            {
                StartCoroutine(StartDeathSequence());
            }
        }
    }

    private IEnumerator StartDeathSequence()
    {
        isDead = true;
        _animator.SetBool("Dead", true);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(deathSceneIndex);
    }
}