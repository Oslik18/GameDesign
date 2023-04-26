using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_camera : MonoBehaviour
{
    public GameObject camera_robot;
    public GameObject camera_spaceship;
    public static bool camera_space;
    // Start is called before the first frame update
    void Start()
    {
        camera_robot.active = false;
        camera_space = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (camera_space)
            {
                camera_space = false;
            }
            else if (!camera_space)
            {
                camera_space = true;
            }
        }


        if (camera_space)
        {
            camera_robot.active = false;
            camera_spaceship.active = true;
        }
        else if (!camera_space)
        {
            camera_robot.active = true;
            camera_spaceship.active = false;
        }

    }
}
