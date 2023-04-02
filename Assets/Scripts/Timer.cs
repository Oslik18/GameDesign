using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private int min = 0, sec = 29, milsec = 99;
    public TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        milsec--;
        if (milsec == 0)
        {
            milsec = 99;
            sec--;
        }

        if (milsec < 10)
        {
            timer.text = "00:" + sec.ToString() + ":0" + milsec.ToString();
        } else if (sec < 10)
        {
            timer.text = "00:0" + sec.ToString() + ":" + milsec.ToString();
        } else
        {
            timer.text = "00:" + sec.ToString() + ":" + milsec.ToString();
        }
       
        if (sec < 0  && Player.count_object<2)
        {
            timer.text = "FAIL";
        }

        if (sec > 0 && Player.count_object == 2)
        {
            timer.text = "WIN";
        }
    }


    
}
