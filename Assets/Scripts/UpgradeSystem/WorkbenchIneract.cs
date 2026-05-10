using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkbenchIneract : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenuCanvas;
    

    void Start()
    {
        upgradeMenuCanvas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
