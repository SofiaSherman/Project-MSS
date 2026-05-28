using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;


public class Dynamite : MonoBehaviour
{
    [SerializeField] private float fuseTime;
    [SerializeField] public float explosionRadius;

    private float damage = 40;
    private Camera m_camera;
    private Rigidbody rb;
    
    private void Start()
    {
        m_camera = Camera.main;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Explosion());
    }

    public IEnumerator Explosion()
    {
        rb.AddForce(m_camera.transform.forward * 4 + m_camera.transform.up * 2, ForceMode.Impulse); 
        yield return new WaitForSeconds(fuseTime);
        Collider[] exploded = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider c in exploded)
        {
            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (c.gameObject.TryGetComponent(out IDamageable damageable)) damageable.TakeDamage(damage);
            if(rb != null) rb.AddExplosionForce(20 ,transform.position, explosionRadius, 2, ForceMode.Impulse);
                    
        }

        Debug.Log("EXPLODED!!!!!");
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
