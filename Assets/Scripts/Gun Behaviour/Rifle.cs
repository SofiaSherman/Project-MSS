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

        if (targets.Length < 1) return;
        GameObject thing = targets[1].gameObject;
        Physics.Raycast(hit.point, thing.transform.position, out ricochet);
        Debug.DrawRay(hit.point, thing.transform.position * 100, Color.red, 10f);

        //ricochet.collider.gameObject.TryGetComponent(out IDamageable damageable);
        
        //if(hit.collider.gameObject.CompareTag("Head")) damageable.TakeDamage(damage * 2);
        //damageable.TakeDamage(damage);
        
        

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hit.point, 5);
    }
}
