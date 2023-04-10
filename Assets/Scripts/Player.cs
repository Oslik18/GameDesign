using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
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
        
        GetMovementInput();

    }


    void GetMovementInput()
    {

        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (movement.magnitude > 0.1f)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            rotation.x = 0;
            rotation.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5.0f);
        }

        rig.velocity = movement * walkSpeed;

        //movement = Vector3.ClampMagnitude(movement, 1.0f);


        //Debug.Log(movement);
    }


}
