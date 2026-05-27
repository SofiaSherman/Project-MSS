using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float forwardSpeed = 5;
    [SerializeField] public float sideSpeed = 5;
    [SerializeField] public float sprintSpeed = 10;

    private Vector3 moveVelocity;
    private CharacterController characterController;
    private Camera m_Camera;
    
    private float rotationSpeed = 50;
    private float verticalVelocity;
    private float gravity = 4.8f;
    public float VelocityX { get; private set; }
    public float VelocityY { get; private set; }
    
    //weapon related
/*    [SerializeField] private Transform weaponParent;
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();*/
    
    public bool shotgunAvailable = false;
    
    //boost related
    public int movementBoostLevel = 0;
    private bool isCurrentlyBoosting = false;

    private void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        
        

    }

    private void Update()
    {
        TimedSpeedBoost();
        UpdateMoveVelocity();
        UpdateVerticalVelocity();
        UpdateRotation();

        ApplyTotalVelocity();


        
    }
    private void ApplyTotalVelocity()
    {
        var totalVelocity = moveVelocity + verticalVelocity * Vector3.up;
        characterController.Move(totalVelocity * Time.deltaTime);
    }

    private void UpdateMoveVelocity()
    {
        if (isCurrentlyBoosting)
        {
            forwardSpeed = 10;
            sideSpeed = 10;
            sprintSpeed = 15;
        }
        else
        {
            forwardSpeed = 5;
            sideSpeed = 5;
            sprintSpeed = 10;
        }
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");

        Vector3 input = xInput * transform.right + yInput * transform.forward;

        if (input.sqrMagnitude > 1) input.Normalize();


        if (Input.GetKey(KeyCode.LeftShift))
        {
            input = new Vector3(input.x * sprintSpeed, 0, input.z * sprintSpeed);

        }
        else
        {
            input = new Vector3(input.x * forwardSpeed, 0, input.z * sideSpeed);
        }

        moveVelocity = input;
        float maxSpeed = sprintSpeed;
        Vector3 normalizedVelocity = moveVelocity / maxSpeed;
        
        VelocityX = Vector3.Dot(normalizedVelocity, transform.right);
        VelocityY = Vector3.Dot(normalizedVelocity, transform.forward);

            
    }

    private void UpdateVerticalVelocity()
    {
        verticalVelocity -= gravity * Time.deltaTime;
    }
    private void UpdateRotation()
    {
        var mouseInput = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseInput * rotationSpeed * Time.deltaTime, 0 );

    }

    private void TimedSpeedBoost()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (movementBoostLevel > 0 && !isCurrentlyBoosting)
            {
                StartCoroutine(CoroutineBoostMovement());
                movementBoostLevel -= 1;
            }
            
        }
    }

    private IEnumerator CoroutineBoostMovement()
    {
        isCurrentlyBoosting = true;
        yield return new WaitForSeconds(5);
        isCurrentlyBoosting = false;
    }
}
