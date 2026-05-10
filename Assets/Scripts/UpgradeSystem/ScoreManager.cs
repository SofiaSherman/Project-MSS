using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Plus))
        {
            score += 100;
            Debug.Log(score);
        }
    }
}
