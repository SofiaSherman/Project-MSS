using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeManager : MonoBehaviour
{
    /*public bool hasRifle = false;
    public bool hasShotgun = false;
    public bool hasDynamite = false;*/

    private ScoreManager scoreManager;
    private GunManager _gunManager;
    
    [SerializeField] private GameObject weaponUpgradeMenuCanvas;
    
    [SerializeField] private int weaponType;
    [SerializeField] private GameObject weapon;
    [SerializeField] private int cost;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private GameObject button;

    [SerializeField] private BoxCollider boxTrigger;
    
    [SerializeField] private GameObject[] buttons;
    
    private WeaponUpgradeManager _weaponUpgradeManager;
    
    [SerializeField] private GameObject pauseMenuObject;
    private PauseMenu pauseMenu;
    

    private void Start()
    {
        weaponUpgradeMenuCanvas.SetActive(false);
        
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        _gunManager = GameObject.FindWithTag("Player").GetComponent<GunManager>();

        _weaponUpgradeManager = GetComponent<WeaponUpgradeManager>();
        
        pauseMenu = pauseMenuObject.GetComponent<PauseMenu>();

    }

    private void EnableScript()
    {
        costText.text = "Cost: " + cost.ToString();
    }

    public void CheckIfCanUpgrade()
    {
        if (scoreManager.score >= cost)
        {
            scoreManager.score -= cost;
            GetWeaponUpgrade();
        }
    }

    private void GetWeaponUpgrade()
    {
        switch (weaponType)
        {
            case 1:
                _gunManager.hasRifle = true;
                break;
            case 2:
                _gunManager.hasShotgun = true;
                break;
            case 3:
                _gunManager.hasDynamite = true;
                break;
        }
        weaponUpgradeMenuCanvas.SetActive(!weaponUpgradeMenuCanvas.activeSelf);
        weapon.SetActive(false);
        
        boxTrigger.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _weaponUpgradeManager.enabled = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Entered");
            EnableScript();
            weaponUpgradeMenuCanvas.SetActive(!weaponUpgradeMenuCanvas.activeSelf);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[weaponType - 1].SetActive(true);
            
            pauseMenu.UpgradePauseGame();
            //Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pauseMenu.UpgradeResumeGame();
            weaponUpgradeMenuCanvas.SetActive(!weaponUpgradeMenuCanvas.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
