using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class test_movement : MonoBehaviour
{
    private GameObject effectSmall;
    private GameObject effectBoom;
    private GameObject effectGate;
    private Slider timeSliderMain;
    public static int player_destroy;
    private bool go;
    private float rotatY = 0f;
    public static float walkSpeed = 60f;
    private float baseWalkSpeed = 60f; // Added variable for base walking speed

    private float turnSpeed = 50f;

    private float xMin = 20f, xMax = 980f, zMin = 20f, zMax = 980f, yMin = 2;

    void Start()
    {
        timeSliderMain = GameObject.Find("Time Bar").GetComponent<Slider>();
        player_destroy = 0;
        effectSmall = GameObject.Find("SmallFire");
        effectBoom = GameObject.Find("Boom");
        effectGate = GameObject.Find("Star_A");
        effectGate.SetActive(false);
        effectSmall.SetActive(false);
        effectBoom.SetActive(false);

        baseWalkSpeed = walkSpeed; // Set the initial value of baseWalkSpeed to walkSpeed
    }

    void Update()
    {
        if (UI_Scenes.boom == 1)
        {
            effectBoom.SetActive(true);
            Invoke("HideObject", 0.6f);

            UI_Scenes.boom++;
            player_destroy = 1;
        }
    }

    void FixedUpdate()
    {
        if (!Change_camera.camera_space)
        {
            GetMovementInput();
        }
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        float timeHeldDown = 0f;
        float maxSpeedMultiplier = 2f;
        float accelerationTime = 1f;

        while (Input.GetAxis("Vertical") != 0f)
        {
            timeHeldDown += Time.deltaTime;
            float speedMultiplier = Mathf.Clamp(timeHeldDown / accelerationTime, 1f, maxSpeedMultiplier);
            walkSpeed = baseWalkSpeed * speedMultiplier;

            yield return null;
        }

        // Reset speed back to base value
        walkSpeed = baseWalkSpeed;
    }

    void GetMovementInput()
    {
        if (timeSliderMain.value < 11)
        {
            effectSmall.SetActive(true);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontalInput * turnSpeed * Time.deltaTime, 0);

        if (Input.GetButtonDown("Vertical"))
        {
            StartCoroutine(IncreaseSpeedOverTime());
        }

       float verticalInput = Input.GetAxis("Vertical");
Vector3 movement = Vector3.zero;
if (verticalInput > 0) // Move forward if the vertical input is positive
{
    movement = transform.forward * verticalInput;
}
else if (verticalInput < 0) // Move backwards if the vertical input is negative
{
    movement = -transform.forward * Mathf.Abs(verticalInput);
}
transform.position += movement * Time.deltaTime * walkSpeed;
    }

    public float RestrictionAngle(float angle)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        else if (angle < -180)
        {
            angle += 360;
        }
        return angle;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            effectGate.SetActive(true);
            player_destroy = 2;
            Invoke("HideObject", 0.2f);
        }
    }

    void HideObject()
    {
        gameObject.SetActive(false);
    }
}
