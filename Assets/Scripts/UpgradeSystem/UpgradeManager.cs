using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    private GameObject player;

    private Revolver playerRevolver;
    private Rifle playerRifle;
    private Shotgun playerShotgun;
    private DynamiteSpawn  playerDynamiteSpawn;
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
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        
        GameObject playerObj = GameObject.Find("Player");
        
        playerRevolver = playerObj.GetComponent<Revolver>();
        playerRifle = playerObj.GetComponent<Rifle>();
        playerShotgun = playerObj.GetComponent<Shotgun>();
        playerDynamiteSpawn = playerObj.GetComponent<DynamiteSpawn>();
        
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
                    UpgradeDamage(i);
                }
            }
            scoreManager.score -= 400;
        }
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
            if (revolverAmmoLevel < 5)
            {
            playerRevolver.ammoTotal += 12;
            revolverAmmoLevel += 1;
            Debug.Log("Ammo upgraded, " + revolverAmmoLevel);
            visualLevelUpgrade.VisualUpgrade(revolverAmmoLevel, 2);
            }
        }
        else if (activePageIndex == 2)
        {
            if (rifleAmmoLevel < 5)
            {
                playerRifle.ammoTotal += 12;
                rifleAmmoLevel += 1;
                visualLevelUpgrade.VisualUpgrade(rifleAmmoLevel, 4);
            }
        }
        else if (activePageIndex == 3)
        {
            if (shotgunAmmoLevel < 5)
            {
                
            playerShotgun.ammoTotal += 8;
            shotgunAmmoLevel += 1;
            Debug.Log("Ammo upgraded, " + shotgunAmmoLevel);
            visualLevelUpgrade.VisualUpgrade(shotgunAmmoLevel, 6);
            }

        }
        else if (activePageIndex == 4)
        {
            if (dynamiteAmmoLevel < 5)
            {
                playerDynamiteSpawn.ammoTotal += 1;
                dynamiteAmmoLevel += 1;
                visualLevelUpgrade.VisualUpgrade(dynamiteAmmoLevel, 8);
            }
            
        }
    }

    private void UpgradeDamage(int activePageIndex)
    {
        if (activePageIndex == 1)
        {
            if (revolverDamageLevel < 5)
            {
                playerRevolver.damage += 2;
                revolverDamageLevel += 1;
                visualLevelUpgrade.VisualUpgrade(revolverDamageLevel, 3);
            }
        }
        else if (activePageIndex == 2)
        {
            if (rifleDamageLevel < 5)
            {
                playerRifle.damage += 2;
                rifleDamageLevel += 1;
                visualLevelUpgrade.VisualUpgrade(rifleDamageLevel, 5);
            }
        }
        else if (activePageIndex == 3)
        {
            if (shotgunDamageLevel < 5)
            {
                playerShotgun.damage += 2;
                shotgunDamageLevel += 1;
                visualLevelUpgrade.VisualUpgrade(shotgunDamageLevel, 7);
            }

        }
        else if (activePageIndex == 4)
        {
            if (dynamiteDamageLevel < 5)
            {
                playerDynamiteSpawn.damage += 2;
                dynamiteDamageLevel += 1;
                visualLevelUpgrade.VisualUpgrade(dynamiteDamageLevel, 9);
            }
        }
        scoreManager.score -= 200;

    }

    public void UpgradeHealth()
    {
        if (scoreManager.score >= 400)
        {
            if (playerHealthLevel < 5)
            {
                playerManager.Health += 1;
                playerHealthLevel++;
                visualLevelUpgrade.VisualUpgrade(playerHealthLevel, 1);

                scoreManager.score -= 400;
                
            }
        }
    }


    public void BoostMovement()
    {
        if (scoreManager.score >= 200)
        {
            playerMovement.movementBoostLevel += 1;
            scoreManager.score -= 200;
        }
    }
    
}
