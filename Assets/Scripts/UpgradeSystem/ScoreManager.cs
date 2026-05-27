using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] public TMP_Text scoreText;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            score += 100;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void PickUpGun()
    {
        
    }
}
