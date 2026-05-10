using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class Guns : MonoBehaviour
{
    [SerializeField] public TMP_Text ammoText;
    [SerializeField] public TMP_Text totalAmmoText;
    [SerializeField] public GameObject shootingPoint;


    public float damage;
    protected float bulletAmount;
    protected float bulletDistance;
    protected float ammoCapacity;
    public float AmmoCount { get; protected set; }
    public float ammoTotal;
    protected float reloadTime;
    protected float counter = 0;

    protected float ZoomValue = 20;


    protected Camera m_Camera;

    protected virtual void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }
    protected virtual void Shoot()
    {
        //do you have bullets left?
        if (AmmoCount > 0)
        {
            AmmoCount--;
            //take one bullet, and fire the bullet/pellet amount which can be modified
            for (int i = 0; i < bulletAmount; i++)
            {
                RaycastHit hit;

                if (Physics.Raycast(shootingPoint.transform.position, m_Camera.transform.forward, out hit, bulletDistance))
                {
                    //does it hit an object that has an enemy script?
                    if (hit.collider.gameObject.GetComponent<EnemyManager>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EnemyManager>().ReceiveDamage(damage);
                    }
                    Debug.DrawRay(shootingPoint.transform.position, m_Camera.transform.forward, Color.red, 3f);
                }

            }
        }
        else Debug.Log("no ammo");
    }
    protected virtual void ReloadGun()
    {
        //is your ammo capacity full?
        if (AmmoCount == ammoCapacity) Debug.Log("full ammo");
        else
        {
            //reload while the ammoCount is not equal to the capacity AND you still have stockpile left
            while (AmmoCount != ammoCapacity && ammoTotal > 0)
            {
                //reload and reset until full
                counter += Time.deltaTime;
                if (counter > reloadTime)
                {
                    AmmoCount++;
                    ammoTotal--;
                    counter = 0;
                }
            }
        }
    }

}
