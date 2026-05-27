
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
        reloadTime = 1.5f;
        bulletAmount = 10;
        damage = 2;
        bulletDistance = 100;
        shotCooldown = 2;

        minZoom = 60;
        maxZoom = 40;
    }
    protected override void Update()
    {
        base.Update();
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (powerCooldown < 40) return;
            powerCounter = 0;
            powerActive = true;
        }
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
    }
    protected override void Shoot()
    {
        if (powerActive)
        {
            PowerUp();
            return;
        }
        if (ammoCount > 0)
        {
            if (shotCounter < shotCooldown) return;
            shotCounter = 0;
            ammoCount--;
            for (int i = 0; i < bulletAmount; i++)
            {
                //the shotgun is different, as in it has more than one "bullet", in pellets
                float randomX = Random.Range(-0.1f, 0.1f);
                float randomY = Random.Range(-0.1f, 0.1f);
                //each bullet will have their own direction


                Vector3 shootVector = m_Camera.transform.forward;
                shootVector += new Vector3(randomX, randomY, 0);
                //that vector is applied to the raycast each time
                if (Physics.Raycast(shootingPoint.transform.position, shootVector, out RaycastHit hit, bulletDistance))
                {
                    if (hit.collider.gameObject.TryGetComponent(out IDamageable damaged))
                    {
                        damaged.TakeDamage(damage);
                    }
                    Debug.DrawRay(shootingPoint.transform.position, shootVector * 100, Color.red, 3f);
                }
            }
            _audioManager.PlaySound("shotgunShot");
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
        shotCounter = shotCooldown;
        StopAllCoroutines();
    }

    protected override void PowerUp()
    {
        RaycastHit hit;
        Physics.Raycast(shootingPoint.transform.position, m_Camera.transform.forward, out hit, bulletDistance);
        Collider[] exploded = Physics.OverlapSphere(hit.point, 5);
        foreach (Collider c in exploded)
        {
            if(c.tag != "Enemy") continue;
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (c.gameObject.TryGetComponent(out IDamageable damageable)) damageable.TakeDamage(30);
            if (rb != null) rb.AddExplosionForce(20, hit.point, 5, 2, ForceMode.Impulse);
        }
        powerCooldown = 0;
        powerActive = false;
    }
}