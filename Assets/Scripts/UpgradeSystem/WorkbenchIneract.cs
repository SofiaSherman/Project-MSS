using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkbenchIneract : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenuCanvas;
    
    /*[SerializeField] private TMP_Text interactionText;
    [SerializeField] private TMP_Text interactionDenyText;

    private float interactionDistance = 10f;
    
    private PlayerMovement playerMovement;

    private float score = 9f;
    
    private bool canInteract = false;

    [SerializeField] private GameObject shotgunModel;*/

    void Start()
    {
        upgradeMenuCanvas.SetActive(false);
        /*interactionText.gameObject.SetActive(false);
        interactionDenyText.gameObject.SetActive(false);
        playerMovement = GetComponent<PlayerMovement>();*/
    }

    private void Update()
    {
       /* if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckScore();
            }
        }*/
    }

    /*private void CheckScore()
    {
        if (score == 10)
        {
            playerMovement.shotgunAvailable = true;
            shotgunModel.gameObject.SetActive(false);
        }
        else
        {
            interactionDenyText.gameObject.SetActive(true);
        }
    }*/
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "InteractableBench")
        {
            upgradeMenuCanvas.SetActive(!upgradeMenuCanvas.activeSelf);
        }
    }
}
