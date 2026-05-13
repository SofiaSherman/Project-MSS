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
    [SerializeField] public GunStash currentGun;
    [SerializeField] public Guns[] currentGuns;
    
    
    public bool hasRifle = false;
    public bool hasShotgun = false;
    public bool hasDynamite = false;
    
    private WeaponUpgradeManager _weaponUpgradeManager;
    private void Start()
    {
        _weaponUpgradeManager = GameObject.FindWithTag("InteractableWeaponBench").GetComponent<WeaponUpgradeManager>();
        ChangeGun(0);
    }
    private void Update()
    {
        WeaponChanger();
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
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasShotgun)
        {
            ChangeGun(GunStash.Shotgun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && hasRifle)
        {
            ChangeGun(GunStash.Rifle);
        }
        if (Input.GetKeyDown(KeyCode.G) && hasDynamite)
        {
            ChangeGun(GunStash.Dynamite);
        }
    }
}
