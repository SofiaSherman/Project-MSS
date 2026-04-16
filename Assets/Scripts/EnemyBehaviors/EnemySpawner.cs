using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject spawnedObject;
    [SerializeField] public float interval;

    private bool activeSpawner;

    private void Start()
    {
        activeSpawner = true;
        StartCoroutine(Spawner());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) activeSpawner = false;
        if(Input.GetKeyDown(KeyCode.M)) activeSpawner = true;
    }

    private IEnumerator Spawner()
    {
        while (activeSpawner == true)
        {
            Instantiate(spawnedObject, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}
