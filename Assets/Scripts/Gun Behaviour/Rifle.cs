using Unity.VisualScripting;
using UnityEngine;

public class Rifle : Guns
{
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        ammoCount = 15;
        ammoCapacity = 15;
        ammoTotal = 45f;

        //other statistics
        reloadTime = 4;
        bulletAmount = 1;
        damage = 10;
        bulletDistance = 100;

        minZoom = 60;
        maxZoom = 20;
    }
    private void Update()
    {
        counter += Time.deltaTime;
        UpdateText();
        UpdateInput();
        CameraZoom();
    }
    private void UpdateText()
    {
        totalAmmoText.text = ammoTotal.ToString();
        ammoText.text = ammoCount + " / " + ammoCapacity;
    }
    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
        //CameraZoom();
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
    }

    private void OnEnable()
    {
        StopAllCoroutines();
    }
}
