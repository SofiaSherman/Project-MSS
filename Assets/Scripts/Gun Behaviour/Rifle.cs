using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Rifle : Guns
{
    private GameObject closestEnemy;
    
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        ammoCount = 15;
        ammoCapacity = 15;
        ammoTotal = 45f;

        //other statistics
        reloadTime = 1.5f;
        bulletAmount = 1;
        damage = 10;
        bulletDistance = 100;
        shotCooldown = 4;

        minZoom = 60;
        maxZoom = 20;
        
    }


    protected override void Update()
    {
        base.Update();
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
    }

    protected override void Shoot()
    {
        base.Shoot();
        _audioManager.PlaySound("rifleShot");
        if (_abilityManager.hasUpgradedRifle)
        {
            
            if (powerActive == true && hit.collider.tag == "Enemy" && ammoCount > 0) PowerUp();
        }
    }
    private void OnEnable()
    {
        shotCounter = shotCooldown;
        StopAllCoroutines();
    }

    protected override void PowerUp()
    {
        Collider[] colliders = Physics.OverlapSphere(hit.point, 5);

        float minDistance = 10;
        foreach (var collider in colliders)
        {
            if (collider.tag != "Enemy") continue;
            float distance = Vector3.Distance(collider.gameObject.transform.position, hit.point);

            if (distance < minDistance && distance >= 1)
            {
                minDistance = distance;
                closestEnemy = collider.gameObject;
            }
            else continue;
        }

        //i'm cheesing the ricochet, raycasts are fucking glorpshit for ricochet, this is fucking glorpshit too but beats not having a ricochet
        //to team: just dress it up as a ricochet and have the enmy take a blood particle upon impact
        //on the small chance that you happen to be here and see this, hi David.
        closestEnemy.GetComponent<IDamageable>()?.TakeDamage(damage * 0.5f);
        Debug.DrawLine(hit.point, closestEnemy.transform.position, Color.blue, 5);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hit.point, 5);
    }
}
