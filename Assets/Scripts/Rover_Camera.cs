using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover_Camera : MonoBehaviour
{
    public Transform rover;
    private Vector3 offsetPosition = new Vector3(0f, 50f, -68f);
    private float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        //offsetPosition = new Vector3(24f, 24f, -34f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPosition = rover.TransformPoint(offsetPosition);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        var direction = rover.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
