using System;
using System.Collections;
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
    private PlayerMovement playerMovement;
    private PlayerManager playerManager;
    
    private ScoreManager scoreManager;
    
    [SerializeField] private VisualLevelUpgrade visualLevelUpgrade;
    
    private int playerSpeedLevel = 0;
    private int playerHealthLevel = 0;
    private int revolverDamageLevel = 0;
    private int revolverAmmoLevel = 0;
    private int rifleDamageLevel = 0;
    private int rifleAmmoLevel = 0;
    private int shotgunDamageLevel = 0;
    private int shotgunAmmoLevel = 0;
    private int dynamiteDamageLevel = 0;
    private int dynamiteAmmoLevel = 0;
    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        
        GameObject playerObj = GameObject.Find("Player");
        
        playerRevolver = playerObj.GetComponent<Revolver>();
        //playerRifle = playerObj.GetComponent<Rifle>();
        playerShotgun = playerObj.GetComponent<Shotgun>();
        //playerDynamite = playerObj.GetComponent<Dynamite>();
        
        playerMovement  = playerObj.GetComponent<PlayerMovement>();
        playerManager =  playerObj.GetComponent<PlayerManager>();

        visualLevelUpgrade = GetComponent<VisualLevelUpgrade>();
    }

    public void CanUpgradeDamage()
    {
        if (scoreManager.score >= 200)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i].activeSelf)
                {
                    UpgradeDamage(i);
                }
            }
            scoreManager.score -= 200;
        }
    }
    public void CanUpgradeDamage400()
    {
        if (scoreManager.score >= 400)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i].activeSelf)
                {
                }
            }
        }
        scoreManager.score -= 400;
    }

    public void CanUpgradeAmmo()
    {
        if (scoreManager.score >= 200)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i].activeSelf)
                {
                    UpgradeAmmo(i);
                }
            }

            scoreManager.score -= 200;
        }
    }
    public void CanUpgradeAmmo400()
    {
        if (scoreManager.score >= 400)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i].activeSelf)
                {
                    UpgradeAmmo(i);
                }
            }
            scoreManager.score -= 400;
        }
    }

    private void UpgradeAmmo(int activePageIndex)
    {
        if (activePageIndex == 1)
        {
            playerRevolver.ammoTotal += 12;
            revolverAmmoLevel += 1;
            Debug.Log("Ammo upgraded, " + revolverAmmoLevel);
            visualLevelUpgrade.VisualUpgrade(revolverAmmoLevel);
        }
        else if (activePageIndex == 2)
        {
        }
        else if (activePageIndex == 3)
        {
            playerShotgun.ammoTotal += 8;
            shotgunAmmoLevel += 1;
            Debug.Log("Ammo upgraded, " + shotgunAmmoLevel);
            visualLevelUpgrade.VisualUpgrade(shotgunAmmoLevel);

        }
        else if (activePageIndex == 4)
        {
            
        }
    }

    private void UpgradeDamage(int activePageIndex)
    {
        if (activePageIndex == 1)
        {
            playerRevolver.damage += 2;
            revolverDamageLevel += 1;
            visualLevelUpgrade.VisualUpgrade(revolverDamageLevel);
        }
        else if (activePageIndex == 2)
        {
        }
        else if (activePageIndex == 3)
        {
            playerShotgun.damage += 2;
            shotgunDamageLevel += 1;
            visualLevelUpgrade.VisualUpgrade(shotgunDamageLevel);

        }
        else if (activePageIndex == 4)
        {
            
        }
        scoreManager.score -= 200;

    }

    private void UpgradeHealth()
    {
        if (scoreManager.score >= 200)
        {
            playerManager.Health += 1;
        }
    }
    

    
    public IEnumerator CoroutineBoostMovement()
    {
        if (scoreManager.score >= 100)
        {
            playerMovement.forwardSpeed = 10;
            playerMovement.sideSpeed = 10;
            playerMovement.sprintSpeed = 20;
            yield return new WaitForSeconds(5);
            playerMovement.forwardSpeed = 5;
            playerMovement.sideSpeed = 5;
            playerMovement.sprintSpeed = 10;
        }
    }
}
