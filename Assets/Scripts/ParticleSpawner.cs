using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticle;
    [SerializeField] private GameObject explosionparticle;
    [SerializeField] private GameObject ExplosionVisual;

    public void SpawnDamageParticle(GameObject body)
    {
        Instantiate(bloodParticle, body.transform.position, Quaternion.identity);
    }

    public void SpawnExplosionParticle(GameObject body)
    {
        Instantiate(explosionparticle, body.transform.position, Quaternion.identity);
    }

    public void SpawnExplosionVisual(GameObject body)
    {
        Instantiate(ExplosionVisual, body.transform.position, Quaternion.Euler(Vector3.one * -90));
    }
    public void SpawnExplosionBullet(Vector3 pos)
    {
        Instantiate(ExplosionVisual, pos, Quaternion.Euler(Vector3.one * -90));
    }
}
