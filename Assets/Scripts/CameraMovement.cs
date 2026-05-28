using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float rotationSpeed = 20;
    private Vector3 rotation;

    private float horizontalRotation;
    private float verticalRotation;

    private void Start()
    {

    }
    private void Update()
    {
        HorizontalCameraMovement();
        VerticalCameraMovement();

        TotalRotation();
    }

    private void HorizontalCameraMovement()
    {
        var mouseInput = Input.GetAxisRaw("Mouse X");
        horizontalRotation = mouseInput * rotationSpeed;


    }

    private void VerticalCameraMovement()
    {
        var mouseInput = Input.GetAxisRaw("Mouse Y");
        verticalRotation = -mouseInput * rotationSpeed;

    }

    private void TotalRotation()
    {
        var pitch = transform.localEulerAngles;
        rotation = new Vector3(verticalRotation, 0 , 0) * Time.deltaTime;
        rotation.z = 0;

        pitch += rotation;
        if (pitch.x > 50) pitch.x -= 360;
        if (pitch.x < -20) pitch.x = -20;
        pitch = new Vector3 (Mathf.Clamp(pitch.x, -20, 45),0,0);
        transform.localEulerAngles = pitch;
    }
}
