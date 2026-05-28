using TMPro;
using UnityEngine;

    public enum GunStash
    {
        Revolver,
        Shotgun,
        Rifle,
        Dynamite
    }

[RequireComponent(typeof(Revolver), typeof(Shotgun), typeof(Rifle))]
[RequireComponent (typeof(DynamiteSpawn))]

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject modelRevolver;
    [SerializeField] private GameObject modelShotgun;
    [SerializeField] private GameObject modelRifle;
    [SerializeField] private GameObject modelDynamite;
    
    [SerializeField] public GunStash currentGun;
    [SerializeField] public Guns[] currentGuns;
    
    
    public bool hasRifle = false;
    public bool hasShotgun = false;
    public bool hasDynamite = false;
    
    private WeaponUpgradeManager _weaponUpgradeManager;
    private PlayerHealth _playerHealth;
    [SerializeField] public AbilityManager _abilityManager;
    
    private void Start()
    {
        _abilityManager = GetComponent<AbilityManager>();
        _weaponUpgradeManager = GameObject.FindWithTag("InteractableWeaponBench").GetComponent<WeaponUpgradeManager>();
        _playerHealth = GetComponent<PlayerHealth>();
        ChangeGun(0);
    }
    private void Update()
    {
        if (!_playerHealth.isDead)
        {
            
            WeaponChanger();
        }
    }

    private void ChangeGun(GunStash newGun)
    {
        currentGun = newGun;
        for(int i = 0; i < currentGuns.Length; i++)
        {
            currentGuns[i].enabled = i == (int)currentGun;
        }
    }

    private void WeaponChanger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(GunStash.Revolver);
            
            modelRevolver.SetActive(true);
            modelShotgun.SetActive(false);
            modelRifle.SetActive(false);
            modelDynamite.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasShotgun)
        {
            ChangeGun(GunStash.Shotgun);
            
            modelRevolver.SetActive(false);
            modelShotgun.SetActive(true);
            modelRifle.SetActive(false);
            modelDynamite.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasRifle)
        {
            ChangeGun(GunStash.Rifle);
            
            modelRevolver.SetActive(false);
            modelShotgun.SetActive(false);
            modelRifle.SetActive(true);
            modelDynamite.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.G) && hasDynamite)
        {
            ChangeGun(GunStash.Dynamite);
            
            modelRevolver.SetActive(false);
            modelShotgun.SetActive(false);
            modelRifle.SetActive(false);
            modelDynamite.SetActive(true);
        }
    }
}
