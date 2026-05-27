using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticle;
    [SerializeField] private GameObject explosionparticle;


    public void SpawnDamageParticle(GameObject body)
    {
        Instantiate(bloodParticle, body.transform.position, Quaternion.identity);
    }

    public void SpawnExplosionParticle(GameObject body)
    {
        Instantiate(explosionparticle, body.transform.position, Quaternion.identity);
    }
}
