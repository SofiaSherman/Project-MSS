using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 100;
    private float forwardSpeed = 10;
    private float sideSpeed = 10;
    private float sprintSpeed = 20;

    private Vector3 moveVelocity;
    private CharacterController characterController;
    private Camera m_Camera;
    
    //animation related
    private bool isMoving = false;
    private Animator animator;

    private void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMoveVelocity();
        UpdateRotation();

        ApplyTotalVelocity();
    }
    private void UpdateMoveVelocity()
    {

        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");

        if (xInput > 0 || yInput > 0)
        {
            animator.SetFloat("VelocityX", 0.5f);
        }
        else
        {
            animator.SetFloat("VelocityX", 0f);
        }

        Vector3 input = xInput * transform.right + yInput * transform.forward;

        if (input.sqrMagnitude > 1) input.Normalize();

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            input = new Vector3(input.x * sideSpeed, 0, input.z * forwardSpeed);
        }
        else
        {
            input = new Vector3(input.x * sprintSpeed, 0, input.z * sprintSpeed);
            animator.SetFloat("VelocityX", 1f);
        }


        moveVelocity = input;
    }
    private void ApplyTotalVelocity()
    {
        var totalVelocity = moveVelocity;
        characterController.Move(totalVelocity * Time.deltaTime);
    }

    private void UpdateRotation()
    {
        var mouseInput = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseInput * rotationSpeed * Time.deltaTime, 0 );
        //transform.Rotate(m_Camera.transform.forward);
    }
}
