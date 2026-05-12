using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Rifle : Guns
{
    public bool powerActive;
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
        if (powerActive == true) PowerUp();
    }
    private void OnEnable()
    {
        StopAllCoroutines();
    }

    protected override void PowerUp()
    {

         //TO DO: FINISH THE RICOCHET SYSTEM, CURRENTLY NOT REDIRECTING
        //power up: ricochet
        Collider[] targets = Physics.OverlapSphere(hit.point, 5);
        RaycastHit ricochet;
        Physics.Raycast(hit.point, targets[2].gameObject.transform.position, out ricochet);
        if (hit.collider.gameObject.TryGetComponent(out IDamageable damageable))
        {
            //if(hit.collider.gameObject.CompareTag("Head")) damageable.TakeDamage(damage * 2);
            damageable.TakeDamage(damage);
        }
        Debug.DrawRay(hit.point, targets[2].gameObject.transform.position * 100, Color.red, 10f);


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hit.point, 5);
    }
}
