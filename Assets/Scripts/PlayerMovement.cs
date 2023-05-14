using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // adjust this value to control the Rover's speed
    public float turnSpeed = 100f; // adjust this value to control the Rover's turning speed
    private GameObject effectSmall;
    private GameObject effectBoom;
    private GameObject effectGate;
    private GameObject effectPortal;
    private Slider timeSliderMain;
    public static int player_destroy;
    private bool go;
    public static float walkSpeed = 40f;

    void Start()
    {
        timeSliderMain = GameObject.Find("Time Bar").GetComponent<Slider>();
        player_destroy = 0;
        effectSmall = GameObject.Find("SmallFire");
        effectBoom = GameObject.Find("Boom");
        effectGate = GameObject.Find("Star_A");
        effectPortal = GameObject.Find("Gateway_effect");
        Debug.Log(effectSmall.name);
        Debug.Log(effectBoom.name);
        Debug.Log(effectGate.name);
        Debug.Log(effectPortal.name);

        effectGate.SetActive(false);
        effectSmall.SetActive(false);
        effectBoom.SetActive(false);
        effectPortal.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
            GetMovementInput();

        if (UI_Scenes.sources == 0 )
        {
            effectPortal.SetActive(true);
        }

        if (UI_Scenes.boom == 1)
        {
            effectBoom.SetActive(true);
            Invoke("HideObject", 0.6f);
            
            UI_Scenes.boom++;
            player_destroy = 1;
        }
    }

    void GetMovementInput()
    {
        if (timeSliderMain.value < 11)
        {
            effectSmall.SetActive(true);
        }

        if (UI_Scenes.boom != 1)
        {
            go = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            go = false;
        }

        if (go && UI_Scenes.boom != 1)
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


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Metal"))
        {
            UI_Scenes.sources--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wood"))
        {
            UI_Scenes.sources--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Rocks"))
        {
            UI_Scenes.sources--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Tools"))
        {
            UI_Scenes.sources--;
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.CompareTag("Finish") && UI_Scenes.sources == 0)
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
