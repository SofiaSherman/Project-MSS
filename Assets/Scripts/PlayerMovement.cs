using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{
    private float rotationSpeed = 50;
    [SerializeField] private float forwardSpeed = 5;
    [SerializeField] private float sideSpeed = 5;
    [SerializeField] private float sprintSpeed = 10;

    private Vector3 moveVelocity;
    private CharacterController characterController;
    private Camera m_Camera;
    
    public float VelocityX { get; private set; }
    public float VelocityY { get; private set; }
    public float TotalVelocity { get; private set; }
    
    //weapon related
    [SerializeField] private Transform weaponParent;
    [SerializeField] private List<GameObject> weapons = new List<GameObject>();
    
    public bool shotgunAvailable = false;

    private void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        
        SetWeapons();

    }

    private void Update()
    {
        Debug.Log(TotalVelocity);
        UpdateMoveVelocity();
        UpdateRotation();

        ApplyTotalVelocity();


        //GetWeapons();
    }

    private void SetWeapons()
    {
        foreach (Transform child in weaponParent)
        {
            weapons.Add(child.gameObject);
        }
    }

    /*private void GetWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[0].gameObject.SetActive(true);
            weapons[1].gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //&& shotgunAvailable)
        {
            weapons[0].gameObject.SetActive(false);
            weapons[1].gameObject.SetActive(true);
        }
    }*/
    private void UpdateMoveVelocity()
    {
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

        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            
            TotalVelocity = Mathf.Lerp(VelocityX + VelocityY, maxSpeed, Time.deltaTime);
        }
        else
        {
            TotalVelocity = Mathf.Lerp(VelocityX + VelocityY, maxSpeed, Time.deltaTime / 2f);
        }*/
            
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
