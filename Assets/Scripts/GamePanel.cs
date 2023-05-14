using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
  private float time;
    public int nextTime;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {      
           
        time += Time.deltaTime;
        if (time >= 1&&nextTime>=0)
        {
            min();
            nextTime--;
            time = 0;
            GetControl<Image>("Red").fillAmount -=1/240f;

        }
      if(nextTime<0)
        {
            UIManager.GetInstance().ShowPanel<GameOverPanel>("GameOverPanel");
        }
    }
    void min()
    {
        int s=0;
        int m=0;
        if (nextTime >= 60)
            m =(int) nextTime / 60;
        s =(int) nextTime % 60;
        string sd = s > 9 ? s.ToString() : "0" + s;
     GetControl<Text>("TimeText").text=m+":"+sd;
    }
}
