using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private void Start()
    {
        
    }


    
    public void Death()
    {
        Destroy(gameObject);
    }
}
