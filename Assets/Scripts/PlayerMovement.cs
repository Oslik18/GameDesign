using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public static float walkSpeed = 40.00f;
    public Animator anim;
    private GameObject effect;
    private GameObject effect_Gate;
    public static int player_destroy;
    private bool go;
    private float rotatY = 0;

    void Start()
    {
        player_destroy = 0;
        anim = GetComponent<Animator>();
        anim.SetBool("walk", false);
        effect = GameObject.Find("Star_A");
        effect_Gate = GameObject.Find("Gateway_effect");
        effect.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

        if (UI_Scenes.boom == 1)
        {
            anim.SetBool("walk", false);
            anim.SetTrigger("attack01");
            UI_Scenes.boom++;
            player_destroy = 1;
        }

        if (!Change_camera.camera_space)
        {
            GetMovementInput();
        }
            

    }

    


    void GetMovementInput()
    {
 

        if (Input.GetMouseButtonDown(0) && UI_Scenes.boom != 1)
        {
            go = true;
            anim.SetBool("walk", true);
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            go = false;
            anim.SetBool("walk", false);
        }

        if (go && UI_Scenes.boom !=1)
        {
            transform.position += new Vector3(transform.forward.x, 0.0f, transform.forward.z) * Time.deltaTime * walkSpeed;
            float delta = Input.GetAxis("Mouse X") * 10f;
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
            
            effect_Gate.SetActive(false);
            effect.SetActive(true);
            player_destroy = 2;
            gameObject.SetActive(false);


        }

    }

 }
