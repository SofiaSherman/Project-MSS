using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Rifle : Guns
{
    private GameObject closestEnemy;
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
    }

    protected override void Shoot()
    {
        base.Shoot();
        if (powerActive == true && hit.collider.tag == "Enemy" && ammoCount > 0) PowerUp();
    }
    private void OnEnable()
    {
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
