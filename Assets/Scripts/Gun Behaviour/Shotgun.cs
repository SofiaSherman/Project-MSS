
using UnityEngine;

public class Shotgun : Guns
{
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        ammoCount = 4;
        ammoCapacity = 4;
        ammoTotal = 16;

        //other stats
        reloadTime = 1;
        bulletAmount = 10;
        damage = 2;
        bulletDistance = 100;

        minZoom = 60;
        maxZoom = 40;
    }
    private void Update()
    { 
        //keep updates clean please, only functions ideally
        UpdateText();
        UpdateInput();
        CameraZoom();
    }
    
    private void UpdateText()
    {
        //updates the text in the UI regarding the ammo
        totalAmmoText.text = ammoTotal.ToString();
        ammoText.text = ammoCount + " / " + ammoCapacity;
    }
    private void UpdateInput()
    {
        //input, so it doesn't clutter
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
    }
    protected override void Shoot()
    {
        if (ammoCount > 0)
        {
            ammoCount--;
            for (int i = 0; i < bulletAmount; i++)
            {
                //the shotgun is different, as in it has more than one "bullet", in pellets
                float randomX = Random.Range(-0.1f, 0.1f);
                float randomY = Random.Range(-0.1f, 0.1f);
                //each bullet will have their own direction


                Vector3 shootVector = m_Camera.transform.forward;
                RaycastHit hit;

                shootVector += new Vector3(randomX, randomY, 0);
                //that vector is applied to the raycast each time
                if (Physics.Raycast(shootingPoint.transform.position, shootVector, out hit, bulletDistance))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IDamageable damaged))
                    {
                        damaged.TakeDamage(damage); 
                    }
                    Debug.DrawRay(shootingPoint.transform.position, shootVector * 100 , Color.red, 3f);
                }
            }
        }
        else Debug.Log("no ammo");
    }

    protected override void CameraZoom()
    {
        base.CameraZoom();
    }

    protected override void ReloadGun()
    {
        base.ReloadGun();
    }

    private void OnEnable()
    {
        StopAllCoroutines();
    }
}
