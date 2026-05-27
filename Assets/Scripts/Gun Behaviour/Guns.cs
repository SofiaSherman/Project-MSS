using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class Guns : MonoBehaviour
{
    [SerializeField] public TMP_Text ammoText;
    [SerializeField] public TMP_Text totalAmmoText;
    [SerializeField] public GameObject shootingPoint;
    
    [SerializeField] protected AudioManager _audioManager;

    protected RaycastHit hit;
    public float damage;
    protected float bulletAmount;
    protected float bulletDistance;
    protected float ammoCapacity;
    public float ammoCount;
    public float ammoTotal;
    protected float reloadTime;
    protected float reloadCounter = 0;
    protected float shotCounter = 0;
    protected float shotCooldown;
    protected float powerCooldown;
    protected float powerCounter;

    protected bool powerActive;


    protected float minZoom;
    protected float maxZoom;

    protected Camera m_Camera;
    protected LineRenderer m_LineRenderer;

    protected virtual void Start()
    {
        m_LineRenderer = GetComponentInChildren<LineRenderer>();
        m_Camera = GetComponentInChildren<Camera>();

        shotCounter = shotCooldown;
        m_LineRenderer.startWidth = 0.05f;
        m_LineRenderer.endWidth = 0.05f;
        
        _audioManager.GetComponent<AudioManager>();
    }
    protected virtual void Update()
    {
        reloadCounter += Time.deltaTime;
        shotCounter += Time.deltaTime;
        powerCooldown += Time.deltaTime;
        powerCounter += Time.deltaTime;
    }

    #region Gun operation
    protected virtual void Shoot()
    {
        //do you have bullets left?
        if (ammoCount > 0)
        {
            if (shotCounter < shotCooldown) return;
            shotCounter = 0;
            ammoCount--;
            //take one bullet, and fire the bullet/pellet amount which can be modified
            for (int i = 0; i < bulletAmount; i++)
            {

                if (Physics.Raycast(shootingPoint.transform.position, m_Camera.transform.forward, out hit, bulletDistance))
                {
                    //does it hit an object that has an enemy script?
                    if (hit.collider.gameObject.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.TakeDamage(damage);
                    }
                    m_LineRenderer.SetPositions(new Vector3[2] {shootingPoint.transform.position, hit.point});
                    Debug.DrawRay(shootingPoint.transform.position, m_Camera.transform.forward * 100, Color.red, 3f);
                }
            }

        }
        else Debug.Log("no ammo");
    }

    protected virtual void ReloadGun()
    {
        
        //is your ammo capacity full?
        if (ammoCount == ammoCapacity) Debug.Log("full ammo");
        else
        {
            //reload while the ammoCount is not equal to the capacity AND you still have stockpile left
            if (ammoCount != ammoCapacity && ammoTotal > 0)
            {
                //reload and reset until full
                if (reloadCounter > reloadTime)
                {
                    ammoCount++;
                    ammoTotal--;
                    reloadCounter = 0;
                }
            }
        }
    }

    #endregion

    #region Camera zoom
    protected virtual void CameraZoom()
    {
        if (Input.GetMouseButton(1))
        {
            StopAllCoroutines();
            StartCoroutine(ZoomIn());
        }

        if (Input.GetMouseButtonUp(1))
        {
            StopAllCoroutines();
            StartCoroutine(ZoomOut());
        }
    }
    protected IEnumerator ZoomIn()
    {
        while (m_Camera.fieldOfView >= maxZoom + 2)
        {
            m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, maxZoom, 10f * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
    }
    protected IEnumerator ZoomOut()
    {
        while (m_Camera.fieldOfView <= minZoom - 2)
        {
            m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, minZoom, 10f * Time.deltaTime);
            yield return new WaitForSeconds(0);
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    #endregion


    protected abstract void PowerUp();
}
