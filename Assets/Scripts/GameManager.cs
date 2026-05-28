using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] spawners;
    [SerializeField] private TextMeshProUGUI roundText;

    private int roundCount;
    public float zombieTokens;
    public int doorsOpen;

    private bool startingRound;

    private void Start()
    {
        roundCount = 0;
        zombieTokens = 1;

        UpdateRoundUI();
        NewRound();
    }

    private void Update()
    {
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

        UpdateRoundUI();

        foreach (EnemySpawner e in spawners)
        {
           
            e.activeSpawner = true;
            StartCoroutine(e.Spawner());
        }

        Debug.Log("new round");
        StartCoroutine(RoundStarted());
    }

    private void UpdateRoundUI()
    {
        roundText.text = "Round: " + roundCount;
    }

    public void StopSpawnZombies()
    {
        if (zombieTokens <= 0)
        {
            foreach (EnemySpawner e in spawners)
            {
                e.activeSpawner = false;
                StopCoroutine(e.Spawner());
               
            }
        }
    }
    private IEnumerator RoundStarted()
    {
        yield return new WaitForSeconds(1f);
        startingRound = false;
    }
}