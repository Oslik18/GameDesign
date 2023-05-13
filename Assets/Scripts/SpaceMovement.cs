using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    private Vector3 movement;
    private float movementSpeed = 40.00f;
    private float rotationSpeed = 80.00f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Change_camera.camera_space)
        {
            GetMovementInput();
        }
        
    }

    void GetMovementInput()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Move the Rover forward or backward
        transform.Translate(Vector3.forward * forwardInput * movementSpeed * Time.deltaTime);

        // Turn the Rover left or right
        transform.Rotate(Vector3.up, turnInput * rotationSpeed * Time.deltaTime);
    }
}
