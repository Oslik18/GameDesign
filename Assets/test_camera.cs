using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_camera : MonoBehaviour
{
    public Transform rover;
    private Vector3 offsetPosition = new Vector3(0f, 50f, -68f);
    private float speed = 10f;

    private bool isRotating = false; // added variable to track if the camera is currently rotating
    private Vector3 lastMousePosition; // added variable to store the last mouse position

    // Start is called before the first frame update
    void Start()
    {
        //offsetPosition = new Vector3(24f, 24f, -34f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isRotating) // only follow the rover if not currently rotating
        {
            var targetPosition = rover.TransformPoint(offsetPosition);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

            var direction = rover.position - transform.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0)) // if left mouse button is clicked, start rotating
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) // if left mouse button is released, stop rotating
        {
            isRotating = false;
        }

        if (isRotating) // if currently rotating, update the camera rotation based on mouse movement
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            float mouseX = deltaMousePosition.x;
            float mouseY = deltaMousePosition.y;

            transform.RotateAround(rover.position, Vector3.up, mouseX * Time.deltaTime * speed);
            transform.RotateAround(rover.position, transform.right, -mouseY * Time.deltaTime * speed);

            lastMousePosition = Input.mousePosition;
        }
    }
}
