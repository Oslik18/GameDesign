using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public TextMeshProUGUI hints;
    public TextMeshProUGUI forRegHint;
    private Text text_timer, text_tools, text_rock, text_wood, text_metal, text_drone, text_portal, text_end;
    private float timer = 0f;
    private float sec;
    private bool text;
    private string frase1 = "You have a planet in front of you. \n\nGoal: Get to the portal(it's twinkling) before the time runs out.\n\nSide goal: to collect the planet's resources during the way.";
    private string frase2 = "There are several types of resources: wood, rock, metal, and the tools.\n\nTrees, bushes, rivers, mountains of nature can't be collected.\n\nResources are hidden all over the planet. They are needed in the future for the development of a ship or drone.\n\nHidden in this level are: Wood-2, Tools-4, Metal-2, Rocks-4";
    private string frase3 = "The game has 2 modes: control from the ship, where you can see the planet from above,\n\n and control of the drone what must get to the portal + collect resources.\n\nIf the drone doesn't do it in time, then you lose, because it'll detonate.";
    private string frase4 = "To control the ship, use the keyboard buttons \"Forward\", \"Backward\", \"Left\", \"Right\". The ship can't land on the ground.\n\nTo switch control from the ship to the drone(and back), you need to press the space button by keyboard.\n\nTo control the robot, click on the left mouse button.To turn left or right, move the mouse in the desired direction.";

    // Start is called before the first frame update
    void Start()
    {
        text = false;
        forRegHint.enabled = false;
        hints.text = frase1;
        text_timer = GameObject.Find("Text_timer_hint").GetComponent<Text>();
        text_tools = GameObject.Find("Text_tools_hint").GetComponent<Text>();
        text_rock = GameObject.Find("Text_rock_hint").GetComponent<Text>();
        text_wood = GameObject.Find("Text_wood_hint").GetComponent<Text>();
        text_metal = GameObject.Find("Text_metal_hint").GetComponent<Text>();
        text_drone = GameObject.Find("Text_drone_hint").GetComponent<Text>();
        text_portal = GameObject.Find("Text_portal_hint").GetComponent<Text>();
        text_end = GameObject.Find("Text_end").GetComponent<Text>();

        text_timer.enabled = true; 
        text_portal.enabled = true;
        text_tools.enabled = false;
        text_rock.enabled = false;
        text_wood.enabled = false;
        text_metal.enabled = false;
        text_drone.enabled = false;
        text_end.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sec = Mathf.FloorToInt(timer % 80);

        if (sec == 15 && !text)
        {
            hints.text = frase2;
            text_tools.enabled = true;
            text_rock.enabled = true;
            text_wood.enabled = true;
            text_metal.enabled = true;
        }
            

        if (sec == 35! && !text)
        {
            hints.text = frase3;
            text_tools.enabled = false;
            text_rock.enabled = false;
            text_wood.enabled = false;
            text_metal.enabled = false;
            text_drone.enabled = true;
        }
            

        if (sec == 55 && !text)
        {
            text_timer.enabled = false;
            text_portal.enabled = false;
            text_drone.enabled = false;
            hints.text = frase4;
        }
            

        if (sec == 75 && !text)
        {
            text_end.enabled = true;
            hints.enabled = false;
        }

        if (sec == 79 && !text)
        {
            text_end.enabled = false;
            forRegHint.enabled = true;
            text = true;
        }




    }




}
