using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRover : MonoBehaviour
{
    public Transform target; // The object that the camera will follow
    public float distance = 10.0f; // Distance from the target
    public float height = 5.0f; // Height of the camera
    public float damping = 2.0f; // Speed of camera movement
    public float rotationSpeed = 100.0f; // Speed of camera rotation

    private float mouseX, mouseY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -30f, 60f);

        // Calculate the desired rotation for the camera
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance + Vector3.up * -height);

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
