using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DynamiteSpawn : Guns
{

    [SerializeField] private GameObject dynamiteInstance;

    private Dynamite dynamiteManager;
    protected override void Start()
    {
        dynamiteManager = dynamiteInstance.GetComponentInChildren<Dynamite>();
        base.Start();
        //setting up ammo
        ammoCount = 1;
        ammoCapacity = 1;
        ammoTotal = 5;

        //other statistics
        reloadTime = 1;
        bulletAmount = 1;
        damage = 40;
        bulletDistance = 50;

        minZoom = 60;
        maxZoom = 50;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (powerCooldown < 40) return;
            powerCounter = 0;
            powerActive = true;
        }
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) ReloadGun();
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
        if (powerActive) dynamiteManager.explosionRadius *= 2;
        else dynamiteManager.explosionRadius = 10;
        //do you have bullets left?
        if (ammoCount > 0)
        {
            _audioManager.PlaySound("dynamiteCharge");
            ammoCount--;
            //take one bullet, and fire the bullet/pellet amount which can be modified
            for (int i = 0; i < bulletAmount; i++) Instantiate(dynamiteInstance, shootingPoint.transform.position, m_Camera.transform.rotation);
            if(powerActive) powerCooldown = 0;
            powerActive = false;
        }
        else Debug.Log("no ammo");


    }
    private void OnEnable()
    {
        StopAllCoroutines();
    }

    protected override void PowerUp()
    {
        
    }
}
