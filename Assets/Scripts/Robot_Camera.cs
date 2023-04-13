using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Camera : MonoBehaviour
{
    public Transform robot;
    private Vector3 offsetPosition;


    // Start is called before the first frame update
    void Start()
    {
        offsetPosition = new Vector3(24f, 24f, -34f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = robot.position + offsetPosition;
    }
}
