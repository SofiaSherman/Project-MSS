using Unity.VisualScripting;
using UnityEngine;

public class EnemyExplode : EnemyBase
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float damage;
    [SerializeField] private float explosionStrength;
    
    public bool hasExploded = false;
    
    public void Explode()
    {
        Debug.Log("Explode");
        Collider[] exploded = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider c in exploded)
        {
            if (c.gameObject.TryGetComponent(out IDamageable playerdamage))
            {
                Debug.Log("got damageble");
                if (c.CompareTag("Player"))
                {
                    playerdamage.TakeDamage(damage);
                }
                //c.GetComponent<Rigidbody>().AddForce(-transform.position + transform.up * explosionStrength, ForceMode.Impulse);
            }
        }
        //Destroy(gameObject, 2);
    }
}
