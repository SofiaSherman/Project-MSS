using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 50;
    private float forwardSpeed = 5;
    private float sideSpeed = 5;
    private float sprintSpeed = 10;

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

        Vector3 input = xInput * transform.right + yInput * transform.forward;

        if (input.sqrMagnitude > 1) input.Normalize();

        input = new Vector3(input.x * sprintSpeed, 0, input.z * sprintSpeed);

        moveVelocity = input;
        
        float velocityX = Vector3.Dot(moveVelocity, transform.right);
        float velocityY = Vector3.Dot(moveVelocity, transform.forward);
        
        animator.SetFloat("VelocityY", velocityY, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
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
