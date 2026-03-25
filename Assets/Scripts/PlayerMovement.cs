using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 20;
    private float forwardSpeed = 10;
    private float sideSpeed = 10;

    private Vector3 moveVelocity;
    private CharacterController characterController;
    private Camera m_Camera;

    private void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
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


        input = new Vector3(input.x * sideSpeed, 0, input.z * forwardSpeed);


        moveVelocity = input;
    }
    private void ApplyTotalVelocity()
    {
        var totalVelocity = moveVelocity;
        characterController.Move(totalVelocity * Time.deltaTime);
    }

    private void UpdateRotation()
    {
        /*var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");
        
        Vector2 lookVector = yInput * m_Camera.transform.forward + xInput * m_Camera.transform.right;
        if(lookVector.sqrMagnitude > 1) lookVector.Normalize();

        lookVector = new Vector3 (0,lookVector.y * m_Camera.transform.forward.z + lookVector.x * m_Camera.transform.right.x, 0) * rotationSpeed;
        transform.Rotate(lookVector);*/
    }
}
