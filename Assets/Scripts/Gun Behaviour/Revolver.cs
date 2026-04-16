using Unity.VisualScripting;
using UnityEngine;

public class Revolver : Guns
{
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        AmmoCount = 6;
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
        ammoText.text = AmmoCount + " / " + ammoCapacity;
    }
    private void UpdateInput()
    {
        if (!PauseMenu.isPaused)
        {

            if (Input.GetMouseButtonDown(0)) Shoot();
            if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
        }
        //CameraZoom();
    }
    /*private void CameraZoom()
    {
        if (Input.GetMouseButton(1)) m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, ZoomValue, 10f);
        if (Input.GetMouseButtonUp(1)) m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, 60, 10f);

    }*/ //TO DO, IMPLEMENT ZOOMING IN, HEAVILY WIP

    protected override void ReloadGun()
    {
        base.ReloadGun();
    }
    protected override void Shoot()
    {
        base.Shoot();
    }
}
