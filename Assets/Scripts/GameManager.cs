using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] spawners;

    private int roundCount;
    public float zombieTokens;
    public int doorsOpen;

    private bool startingRound;

    private void Start()
    {
        roundCount = 0;
        zombieTokens = 1;
        NewRound();
    }

    private void Update()
    {
        //Debug.Log("is updating");
        //Debug.Log(startingRound);
        //Debug.Log(zombieTokens);
        //Debug.Log(roundCount);
        EnemyManager thing = (EnemyManager)FindAnyObjectByType(typeof(EnemyManager));
        StopSpawnZombies();
        if (thing == null && !startingRound)
        {
            startingRound = true;
            Debug.Log("Call new round");
            NewRound();
        }
    }
    private void NewRound()
    {
        roundCount++;
        zombieTokens = 1 + (roundCount);
        foreach (EnemySpawner e in spawners)
        {
            e.activeSpawner = true;
            StartCoroutine(e.Spawner());
        }
        Debug.Log("new round");
        //startingRound = false;
        StartCoroutine(RoundStarted());

    }

    public void StopSpawnZombies()
    {
        if (zombieTokens <= 0)
        {
            foreach (EnemySpawner e in spawners)
            {
                e.activeSpawner = false;
                StopCoroutine(e.Spawner());
                //Debug.Log("zombies exhausted");
            }
        }
    }

    private IEnumerator RoundStarted()
    {
        yield return new WaitForSeconds(1f);
        startingRound = false;
    }
}
