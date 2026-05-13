using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            score += 100;
        }
    }

    public void PickUpGun()
    {
        
    }
}
