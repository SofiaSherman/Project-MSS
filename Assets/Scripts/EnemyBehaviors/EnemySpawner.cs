using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnedObject;
    [SerializeField] private float interval;
    [SerializeField] private GameManager gameManager;

    private int decision;
    public bool activeSpawner;

    private void Start()
    {
        activeSpawner = true;
        StartCoroutine(Spawner());
    }
    private void Update()
    {
       // if(Input.GetKeyDown(KeyCode.P)) activeSpawner = false;
       // if(Input.GetKeyDown(KeyCode.M)) activeSpawner = true;
    }

    public IEnumerator Spawner()
    {
        while (activeSpawner == true)
        {
            decision = Random.Range(0, gameManager.doorsOpen);
            switch (decision)
            {
                case 0:
                    Instantiate(spawnedObject[decision], transform.position, transform.rotation);
                    gameManager.zombieTokens--;
                    Debug.Log(gameManager.zombieTokens);
                    break;
                case 1:
                    Instantiate(spawnedObject[decision], transform.position, transform.rotation);
                    gameManager.zombieTokens -= 2;
                    break;
                case 2:
                    Instantiate(spawnedObject[decision], transform.position, transform.rotation);
                    gameManager.zombieTokens -= 2;
                    break;
                case 3:
                    Instantiate(spawnedObject[decision], transform.position, transform.rotation);
                    gameManager.zombieTokens -= 2;
                    break;
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
