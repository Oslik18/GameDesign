using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    private Text text_timer, text_source, text_drone, text_portal, text_number;
    private float timer = 0f;
    private float sec;
    private bool text;
    
    // Start is called before the first frame update
    void Start()
    {    
        text_timer = GameObject.Find("Text_timer_hint").GetComponent<Text>();
        text_source = GameObject.Find("Text_source_hint").GetComponent<Text>();
        text_number = GameObject.Find("Text_number_hint").GetComponent<Text>();
        text_drone = GameObject.Find("Text_drone_hint").GetComponent<Text>();
        text_portal = GameObject.Find("Text_portal_hint").GetComponent<Text>();

        text_timer.enabled = true; 
        text_portal.enabled = true;
        text_source.enabled = true;
        text_number.enabled = true;
        text_drone.enabled = true;

        }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sec = Mathf.FloorToInt(timer % 80);

        if (sec == 12 && !text)
        {
            text_timer.enabled = false;
            text_portal.enabled = false;
            text_source.enabled = false;
            text_number.enabled = false;
            text_drone.enabled = false;
        }
    }
}
