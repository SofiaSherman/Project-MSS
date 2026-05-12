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
        zombieTokens = 10;
        NewRound();
    }

    private void NewRound()
    {
        roundCount++;
        zombieTokens = 10 + (roundCount * 1.3f);
        foreach(EnemySpawner e in spawners)
        {
            e.enabled = true;
        }
    }

    private void StopSpawnZombies()
    {
        if (zombieTokens <= 0)
        {
            foreach (EnemySpawner e in spawners)
            {
                e.enabled = false;
            }
        }
    }
}
