using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Random = UnityEngine.Random;

abstract public class Guns : MonoBehaviour
{
    protected float damage;
    protected float bulletAmount;
    protected float bulletDistance;
    protected float ammoCapacity;
    protected float ammoCount;
    protected float ammoTotal;
    protected float reloadTime;
    protected float counter = 0;

    protected Camera m_Camera;

    protected virtual void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }
    protected virtual void Shoot()
    {
        if (ammoCount >= 0)
        {
            ammoCount--;
            for (int i = 0; i < bulletAmount; i++)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, m_Camera.transform.forward, out hit, bulletDistance))
                {
                    Debug.DrawRay(transform.position, m_Camera.transform.forward, Color.red, 3f);
                    Debug.Log(hit.transform.name);
                }

            }
        }
        else Debug.Log("no ammo");
    }
    protected virtual void ReloadGun()
    {
        counter += Time.deltaTime;
        if (counter >= reloadTime)
        {
            reloadTime = 0;
            ammoCount = ammoCapacity;
            ammoTotal -= ammoCapacity;
        }
    }
}