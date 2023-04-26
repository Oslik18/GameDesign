using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //public Animator anim;
    private GameObject effectSmall;
    private GameObject effectBoom;
    private GameObject effectGate;
    private Slider timeSliderMain;
    public static int player_destroy;
    private bool go;
    private float rotatY = 0f;
    public static float walkSpeed = 40f;
    
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

    }
    // Update is called once per frame
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

    private void FixedUpdate()
    {
        if (!Change_camera.camera_space)
        {
            GetMovementInput();
        }
    }


    void GetMovementInput()
    {
        if (timeSliderMain.value < 11)
        {
            effectSmall.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && UI_Scenes.boom != 1)
        {
            go = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            go = false;
        }

        if (go && UI_Scenes.boom != 1)
        {
            transform.position += new Vector3(transform.forward.x, 0.0f, transform.forward.z) * Time.deltaTime * walkSpeed;
            float delta = Input.GetAxis("Mouse X") * 5f;
            rotatY = RestrictionAngle(transform.localEulerAngles.y + delta);
            transform.localEulerAngles = new Vector3(0.0f, rotatY, 0.0f);
        }
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
