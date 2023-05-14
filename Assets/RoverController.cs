using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    public float speed = 10f; // adjust this value to control the Rover's speed
    public float turnSpeed = 100f; // adjust this value to control the Rover's turning speed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handle keyboard input for movement and turning
        float forwardInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Move the Rover forward or backward
        transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);

        // Turn the Rover left or right
        transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
    }
}
