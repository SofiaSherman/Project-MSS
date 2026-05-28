using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class BuyableDoor : MonoBehaviour
{
    [SerializeField] private int scoreRequirement;
    //private Rigidbody body;
    [SerializeField] private GameObject doorUpgradePopUp;
    private bool isBought = false;

    private ScoreManager _scoreManager;
    
    [SerializeField] private TMP_Text costText;
    [SerializeField] private GameObject button;
    
    [SerializeField] private GameObject pauseMenuObject;
    private PauseMenu pauseMenu;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        //body = GetComponent<Rigidbody>();
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
        
        /*if (Input.GetKey(KeyCode.E) && _scoreManager.score >= scoreRequirement)
        {
            doorUpgradePopUp.SetActive(false);
            body.isKinematic = true;
            _scoreManager.score -= scoreRequirement;
            Destroy(gameObject,0.5f);
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pauseMenu.UpgradeResumeGame();
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
            //pauseMenu.UpgradeResumeGame();
            isBought = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            doorUpgradePopUp.SetActive(false);
            //body.isKinematic = true;
            _scoreManager.score -= scoreRequirement;
            Destroy(gameObject, 1f);
        }
    }

}
