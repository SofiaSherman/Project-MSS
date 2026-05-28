using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkbenchIneract : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenuCanvas;
    
    public bool isActive = false;

    [SerializeField] private GameObject pauseMenuObject;
    private PauseMenu pauseMenu;

    void Start()
    {
        upgradeMenuCanvas.SetActive(false);
        pauseMenu = pauseMenuObject.GetComponent<PauseMenu>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
            isActive = true;
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            pauseMenu.UpgradePauseGame();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            isActive = false;
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.UpgradeResumeGame();
        }
    }
}
