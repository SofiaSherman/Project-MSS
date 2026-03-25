using UnityEngine;

public class SS_CowboyAnim : MonoBehaviour
{
    private float velocityX = 0f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shoot_Rifle");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Reload_Rifle");
        }
        
    }
}
