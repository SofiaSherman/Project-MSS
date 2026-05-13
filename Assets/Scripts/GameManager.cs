using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] spawners;

    private int roundCount;
    public float zombieTokens;
    public int doorsOpen;

    private void Start()
    {
        roundCount = 0;
        zombieTokens = 1;
        NewRound();
    }

    private void Update()
    {
        StopSpawnZombies();
        NewRound();
    }
    private void NewRound()
    {
        EnemyManager thing = (EnemyManager)FindAnyObjectByType(typeof(EnemyManager));
        if (thing == null)
        {
            roundCount++;
            zombieTokens = 1 + (roundCount);
            foreach (EnemySpawner e in spawners)
            {
                StartCoroutine(e.Spawner());
                e.activeSpawner = true;
            }
            Debug.Log("new round");
        }
    }

    public void StopSpawnZombies()
    {
        if (zombieTokens <= 0)
        {
            foreach (EnemySpawner e in spawners)
            {
                StopCoroutine(e.Spawner());
                e.activeSpawner = false;
                Debug.Log("zombies exhausted");
            }
        }
    }
}
