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
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * Time.deltaTime * movementSpeed, Space.World);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
