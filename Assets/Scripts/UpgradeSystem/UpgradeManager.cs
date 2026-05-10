using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    private GameObject player;

    private Revolver playerRevolver;
    //private Rifle playerRifle;
    private Shotgun playerShotgun;
    //private Dynamite  playerDynamite;
    private UpgradeTabController  upgradeTabController;

    private void Start()
    {
        upgradeTabController  = GetComponent<UpgradeTabController>();
        
        GameObject playerObj = GameObject.Find("Player");
        playerRevolver = playerObj.GetComponent<Revolver>();
        //playerRifle = playerObj.GetComponent<Rifle>();
        playerShotgun = playerObj.GetComponent<Shotgun>();
        //playerDynamite = playerObj.GetComponent<Dynamite>();
    }

    public void CanUpgradeDamage()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].activeSelf)
            {
                Debug.Log("Upgrade damage");
            }
        }
    }

    public void CanUpgradeAmmo()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i].activeSelf)
            {
                UpgradeAmmo(i);
            }
        }
    }

    private void UpgradeAmmo(int activePageIndex)
    {
        if (activePageIndex == 0)
        {
            playerRevolver.ammoTotal += 12;
        }
        else if (activePageIndex == 1)
        {
            
        }
        else if (activePageIndex == 2)
        {
            playerShotgun.ammoTotal += 8;
        }
        else if (activePageIndex == 3)
        {
            
        }

    }

    private void UpgradeDamage(int activePageIndex)
    {
        if (activePageIndex == 0)
        {
            playerRevolver.damage += 2;
        } 
        else if (activePageIndex == 1)
        {
            
        }
        else if (activePageIndex == 2)
        {
            playerShotgun.damage += 2;
        }
        else if (activePageIndex == 3)
        {
            
        }
    }
    public void VisualUpgrade()
    {
        //images.color = Color.grey;
        Debug.Log("change colour");
    }
}
