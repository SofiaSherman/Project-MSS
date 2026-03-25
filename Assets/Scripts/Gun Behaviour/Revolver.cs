using Unity.VisualScripting;
using UnityEngine;

public class Revolver : Guns
{
    protected override void Start()
    {
        base.Start();
        //setting up ammo
        ammoCount = 6;
        ammoCapacity = 6;
        ammoTotal = 24;

        //other statistics
        reloadTime = 4;
        bulletAmount = 1;
        damage = 10;
        bulletDistance = 100;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }
}
