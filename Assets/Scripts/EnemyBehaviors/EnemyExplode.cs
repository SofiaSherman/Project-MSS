using Unity.VisualScripting;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float damage;
    [SerializeField] private float explosionStrength;
    public void Explode()
    {
        Collider[] exploded = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider c in exploded)
        {
            if (!c.gameObject.TryGetComponent(out IDamageable damageable))
            {
                if (c.gameObject.tag == "Player")
                {
                    damageable.TakeDamage(damage);
                }
                c.GetComponent<Rigidbody>().AddForce(-transform.position + transform.up * explosionStrength, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
