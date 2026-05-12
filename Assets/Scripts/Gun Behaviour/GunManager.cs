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
    private void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(GunStash.Shotgun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeGun(GunStash.Rifle);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeGun(GunStash.Dynamite);
        }
    }
}
