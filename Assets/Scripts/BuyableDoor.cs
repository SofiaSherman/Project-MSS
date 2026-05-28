using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class BuyableDoor : MonoBehaviour
{
    [SerializeField] public EnemySpawner spawner;
    [SerializeField] private int scoreRequirement;
    [SerializeField] private GameObject doorUpgradePopUp;
    public bool isBought = false;
    
    private ScoreManager _scoreManager;
    
    [SerializeField] private TMP_Text costText;
    [SerializeField] private GameObject button;
    
    [SerializeField] private GameObject pauseMenuObject;
    private PauseMenu pauseMenu;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        doorUpgradePopUp.SetActive(false);
        button.SetActive(false);
        
        pauseMenu = pauseMenuObject.GetComponent<PauseMenu>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isBought)
        {
            //pauseMenu.UpgradePauseGame();
            doorUpgradePopUp.SetActive(true);
            button.SetActive(true);
            costText.text = "Cost: " + scoreRequirement.ToString();
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Cursor.visible = false;
            doorUpgradePopUp.SetActive(false);
            button.SetActive(false);
        }
    }

    public void Buy()
    {
        if (_scoreManager.score >= scoreRequirement)
        {
            _gameManager.doorsOpen++;
            isBought = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            doorUpgradePopUp.SetActive(false);
            _scoreManager.score -= scoreRequirement;
            Destroy(gameObject, 1f);
            spawner.activeSpawner = true;
        }
    }

}
