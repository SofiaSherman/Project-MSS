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
    }
    private void Update()
    {
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
                float randomX = Random.Range(-0.2f, 0.2f);
                float randomY = Random.Range(-0.2f, 0.2f);

                Vector3 shootVector = m_Camera.transform.forward;
                RaycastHit hit;

                shootVector += new Vector3(randomX, randomY, 0);
                if (Physics.Raycast(transform.position, shootVector, out hit, bulletDistance))
                {
                    Debug.DrawRay(transform.position, shootVector, Color.red, 3f);
                    Debug.Log(hit.transform.name);
                }
            }
        }
        else Debug.Log("no ammo");
    }
    protected override void ReloadGun()
    {
        if (ammoCount == ammoCapacity) Debug.Log("full ammo");
        else
        {
            while (ammoCount != ammoCapacity)
            {
                
                counter += Time.deltaTime;
                if (counter > 0)
                {
                    ammoCount++;
                    ammoTotal--;
                    Debug.Log(ammoCount + "shells in the chamber");
                    counter = 0;
                }
            }
            Debug.Log("gun realoaded");
        }
    }
}
