using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCarController : MonoBehaviour
{
 
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;
    public Text[] texts=new Text[3];
    private int[] nums=new int[3];
    public float motorForce = 1500f;   
    public float steeringAngle = 30f;   
    public float brakeForce = 3000f;   
    public float maxSpeed = 3000f;
    public GameObject obj;
    void OnTriggerEnter(Collider item)
    {
        
        if(item.gameObject.tag== "Tools")
        {
            nums[0]++;
            texts[0].text = nums[0] + "/4";
        }
        if(item.gameObject.tag== "Metal")
        {
            nums[1]++;
            texts[1].text = nums[1] + "/4";
        }
        if(item.gameObject.tag == "Wood")
        {
            nums[2]++;
            texts[2].text = nums[2] + "/4";
        }
        if (nums[0] == nums[1] && nums[1] == nums[2] && nums[2]== 4)
        {
            obj.SetActive(true);
        }
        if (item.gameObject.tag == "SC")
        {
            print("Level finish");
            //Here next write the car to enter the next Level Sense when it touches the portal
        }
        Destroy(item.gameObject);
    }
    void FixedUpdate()
    {
      
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

       
        ApplyMotorForce(verticalInput);
        SteerWheels(horizontalInput);
    }

    void ApplyMotorForce(float verticalInput)
    {
       
        if (Mathf.Abs(verticalInput) < 0.1f)
        {
            rearLeftWheel.brakeTorque = brakeForce;
            rearRightWheel.brakeTorque = brakeForce;
        }
        else
        {
            rearLeftWheel.brakeTorque = 0;
            rearRightWheel.brakeTorque = 0;

          
            if (rearLeftWheel.rpm <= maxSpeed)
            {
                // Apply motor torque to rear wheel
                rearLeftWheel.motorTorque = verticalInput * motorForce;
                rearRightWheel.motorTorque = verticalInput * motorForce;
            }
            else
            {
                rearLeftWheel.motorTorque = 0;
                rearRightWheel.motorTorque = 0;
            }
        }
    }


    void SteerWheels(float horizontalInput)
    {
       
        float angle = steeringAngle * horizontalInput;

       
        frontLeftWheel.steerAngle = angle;
        frontRightWheel.steerAngle = angle;
    }

    void UpdateWheelVisuals()
    {
        UpdateWheelVisual(frontLeftWheel);
        UpdateWheelVisual(frontRightWheel);
        UpdateWheelVisual(rearLeftWheel);
        UpdateWheelVisual(rearRightWheel);
    }

    void UpdateWheelVisual(WheelCollider wheel)
    {
       
        if (wheel.transform.childCount == 0) return;

        
        Transform wheelMesh = wheel.transform.GetChild(0);

       
        Vector3 wheelPosition;
        Quaternion wheelRotation;
        wheel.GetWorldPose(out wheelPosition, out wheelRotation);

      
        wheelMesh.position = wheelPosition;
        wheelMesh.rotation = wheelRotation;
    }

    private void Update()
    {
        if (transform.position.y <= 25)
        {
            UIManager.GetInstance().ShowPanel<GameOverPanel>("GameOverPanel");
        }
        UpdateWheelVisuals();
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}