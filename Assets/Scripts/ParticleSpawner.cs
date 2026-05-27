using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticle;

    public void SpawnDamageParticle(GameObject body)
    {
        Instantiate(bloodParticle, body.transform.position, Quaternion.identity);
    }
}
