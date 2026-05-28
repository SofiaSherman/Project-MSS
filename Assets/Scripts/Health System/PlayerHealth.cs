using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private PlayerManager p_manager;
    private Animator _animator;

    [SerializeField] public float maxHealth = 10f;
    public float health;
    public bool isDead = false;

    [Header("UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;

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

        // Setup health text
        UpdateHealthUI();
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
        }

        // Update UI
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        // Update slider
        healthSlider.value = health;

        // Update text
        healthText.text = Mathf.RoundToInt(health) + " / " + Mathf.RoundToInt(maxHealth);
    }

    private IEnumerator StartDeathSequence()
    {
        isDead = true;
        _animator.SetBool("Dead", true);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(deathSceneIndex);
    }
}