using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement;
    private float walkSpeed = 10.00f;
    public Animator anim;
    private Rigidbody rig;


    void Start()
    {
        //sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (UI_Scenes.boom == 1)
        {
            anim.SetBool("walk", false);
            anim.SetTrigger("attack01");
            UI_Scenes.boom++;
            Debug.Log(UI_Scenes.boom);
        }
        GetMovementInput();

    }


    void GetMovementInput()
    {

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        rig.velocity = movement * walkSpeed;

        //movement = Vector3.ClampMagnitude(movement, 1.0f);


        //Debug.Log(movement);
    }


}
