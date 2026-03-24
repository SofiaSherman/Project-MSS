using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideSpeed;
    private Vector3 playerVelocity;
    
    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    
    [Header("Vertical")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float stickToGroundVelocity;
    private bool isJumping = false;
    private float verticalVelocity;
    private float gravity = 9.18f;

    private CharacterController characterController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyTotalVelocity();
        
        UpdateMoveVelocity();
        UpdateVerticalVelocity();

        UpdateRotation();
    }
    private void ApplyTotalVelocity()
    {
        var totalVelocity = playerVelocity + verticalVelocity * Vector3.up;
        characterController.Move(totalVelocity * Time.deltaTime);
    }

    private void UpdateMoveVelocity()
    {
        var xInput =  Input.GetAxis("Horizontal");
        var yInput =  Input.GetAxis("Vertical");
        
        var input = xInput * transform.right + yInput * transform.forward;
        if (input.sqrMagnitude > 1)
        {
            input.Normalize();
        }
        
        input = new Vector3(input.x * sideSpeed, 0, input.z * forwardSpeed);
        playerVelocity = input;
    }
    
    private void UpdateVerticalVelocity()
    {
        if (Input.GetAxisRaw("Jump") > 0.5f && characterController.isGrounded && !isJumping)
        {
            isJumping = true;
            verticalVelocity = jumpForce; //not time deltatme as its an instant force that has consequences overtime (gravity)
        }

        if (isJumping && characterController.isGrounded && characterController.velocity.y < 0) //first frame that is it grounded then you hit the ground and youre no longer jumping
        {
            isJumping = false;
        }
    
        if (!isJumping && characterController.isGrounded && characterController.velocity.y < 0)
        {
            verticalVelocity = stickToGroundVelocity;
        }
        verticalVelocity -= gravity * Time.deltaTime;
    }
    private void UpdateRotation()
    {
        var mouseInput = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseInput * rotationSpeed * Time.deltaTime, 0 );
    }
}
