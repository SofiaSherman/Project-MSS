using UnityEngine;

public class SS_CowboyAnim : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");
        
        Vector3 input = xInput * transform.right + yInput * transform.forward;

        if (input.sqrMagnitude > 1) input.Normalize();

        if (input != Vector3.zero)
        {
            animator.SetFloat("VelocityX", xInput);
            animator.SetFloat("Velocityy", yInput);

        }
        
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("VelocityX", 1.1f);
        }
        else
        {
            animator.SetFloat("VelocityX", xInput);
        }*/
            
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
