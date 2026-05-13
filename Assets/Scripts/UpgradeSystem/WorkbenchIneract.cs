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
            
            pauseMenu.UpgradePauseGame();
            //Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            isActive = false;
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
            pauseMenu.UpgradeResumeGame();
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
    }
}
