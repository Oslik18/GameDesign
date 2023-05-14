using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetPosition;
    public Vector3 offSetRotate;
    private bool isRotate;

    public float distance;
    public float scrollSpeed = 10;
    public float RotateSpeed = 2;

    // Use this for initialization
    void Start()
    {
        transform.LookAt(player.position+offSetRotate);
        offsetPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = offsetPosition + player.position;

        RotateView();

        ScrollView();
    }

    void ScrollView()
    {
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 2, 25);
        offsetPosition = offsetPosition.normalized * distance;
    }

    void RotateView()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isRotate = false;
        }

        if (isRotate)
        {
            transform.RotateAround(player.position, player.up, RotateSpeed * Input.GetAxis("Mouse X"));

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;

            transform.RotateAround(player.position, transform.right, -RotateSpeed * Input.GetAxis("Mouse Y"));

            float x = transform.eulerAngles.x;

            if (x < 10 || x > 80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }
        }
        offsetPosition = transform.position - player.position;
    }
}
