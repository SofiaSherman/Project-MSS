using UnityEngine;

public class Shotgun : Guns
{
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        AmmoCount = 4;
        ammoCapacity = 4;
        ammoTotal = 16;

        //other stats
        reloadTime = 1;
        bulletAmount = 10;
        damage = 2;
        bulletDistance = 100;
    }
    private void Update()
    { 
        //keep updates clean please, only functions ideally
        UpdateText();
        UpdateInput();
        
    }
    
    private void UpdateText()
    {
        //updates the text in the UI regarding the ammo
        totalAmmoText.text = ammoTotal.ToString();
        ammoText.text = AmmoCount + " / " + ammoCapacity;
    }
    private void UpdateInput()
    {
        //input, so it doesn't clutter
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
    }
    protected override void Shoot()
    {
        if (AmmoCount > 0)
        {
            AmmoCount--;
            for (int i = 0; i < bulletAmount; i++)
            {
                //the shotgun is different, as in it has more than one "bullet", in pellets
                float randomX = Random.Range(-0.2f, 0.2f);
                float randomY = Random.Range(-0.2f, 0.2f);
                //each bullet will have their own direction


                Vector3 shootVector = m_Camera.transform.forward;
                RaycastHit hit;

                shootVector += new Vector3(randomX, randomY, 0);
                //that vector is applied to the raycast each time
                if (Physics.Raycast(shootingPoint.transform.position, shootVector, out hit, bulletDistance))
                {
                    if (hit.collider.gameObject.GetComponent<EnemyManager>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EnemyManager>().ReceiveDamage(damage);
                    }
                    Debug.DrawRay(shootingPoint.transform.position, shootVector, Color.red, 3f);
                }
            }
        }
        else Debug.Log("no ammo");
    }
    protected override void ReloadGun()
    {
        base.ReloadGun();
    }
}
