using System.Collections;
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
        reloadTime = .5f;
        bulletAmount = 1;
        damage = 5;
        bulletDistance = 100;
        shotCooldown = .5f;
        powerCooldown = 0;

        minZoom = 60;
        maxZoom = 30;
    }
    protected override void Update()
    {
        base.Update();
        UpdateText();
        UpdateInput();
        CameraZoom();

        PowerUp();
        
    }
    private void UpdateText()
    {

        totalAmmoText.text = ammoTotal.ToString();
        ammoText.text = ammoCount + " / " + ammoCapacity;
    }
    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (powerCooldown < 30) return;
            powerCounter = 0;
            powerActive = true;
        }
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
    }

    protected override void CameraZoom()
    {
        base.CameraZoom();
    }

    protected override void ReloadGun()
    {
        base.ReloadGun();
    }
    protected override void Shoot()
    {
        base.Shoot();
        _audioManager.PlaySound("revolverShot");
    }
    private void OnEnable()
    {
        StopAllCoroutines();
    }

    protected override void PowerUp()
    { 
        if (powerActive)
        {
            shotCooldown = 0;
            ammoCount = Mathf.Infinity;
            if (powerCounter > 5)
            {
                ammoCount = ammoCapacity;
                powerActive = false;
                powerCooldown = 0;
            }
        }
    }
}
