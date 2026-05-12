using Unity.VisualScripting;
using UnityEngine;

public class Revolver : Guns
{
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        ammoCount = 6;
        ammoCapacity = 6;
        ammoTotal = 24;

        //other statistics
        reloadTime = 4;
        bulletAmount = 1;
        damage = 5;
        bulletDistance = 100;
    }
    private void Update()
    {
        counter += Time.deltaTime;
        UpdateText();
        UpdateInput();
    }
    private void UpdateText()
    {
        totalAmmoText.text = ammoTotal.ToString();
        ammoText.text = ammoCount + " / " + ammoCapacity;
    }
    private void UpdateInput()
    {
        if (!PauseMenu.isPaused)
        {

            if (Input.GetMouseButtonDown(0)) Shoot();
            if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
        }
    }

    protected override void ReloadGun()
    {
        base.ReloadGun();
    }
    protected override void Shoot()
    {
        base.Shoot();
    }

    protected override void PowerUp()
    {
        
    }
}
