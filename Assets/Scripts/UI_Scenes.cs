using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Scenes : MonoBehaviour
{
    public int minute;
    private int min, sec;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI text_tools;
    public TextMeshProUGUI text_wood;
    public TextMeshProUGUI text_metal;
    public TextMeshProUGUI text_rocks;
    public static int metal_sources = 0;
    public static int wood_sources = 0;
    public static int other_sources = 0;
    public static int rocks_sources = 0;
    public Slider timeSlider;
    private float timeCount;
    public static bool stopTimer;
    public static int boom = 0;

    // Start is called before the first frame update
    void Start()
    {
        Count_tools count_tools = new Count_tools();
        count_tools.LoadFile();
        metal_sources = Count_tools.metal_all_sources;
        wood_sources = Count_tools.wood_all_sources;
        other_sources = Count_tools.other_all_sources;
        rocks_sources = Count_tools.rocks_all_sources;

        stopTimer = false;
        //timeCount = minute * 60;
        //timeSlider.maxValue = minute * 60;
        //timeSlider.value = minute * 60;
        timeCount = 5;
        timeSlider.maxValue = 5;
        timeSlider.value = 5;
    }

    void Update()
    {
        Timer();

        text_tools.text = other_sources.ToString();
        text_wood.text = wood_sources.ToString();
        text_metal.text = metal_sources.ToString();
        text_rocks.text = rocks_sources.ToString();
    }

    public void LoadMenu()
    {
        //if (stopTimer)
        //{
            Debug.Log("qqq");
            Count_tools count_tools = new Count_tools();
            count_tools.WriteFile(other_sources, metal_sources, wood_sources, rocks_sources);
            
        //}
        
        SceneManager.LoadScene("Start");
    }


    public void LoadAgain()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Timer()
    {
        timeCount -= Time.deltaTime;
        
        if (timeCount <= 0)
        {
            stopTimer = true;
            boom++;
            Debug.Log(boom);
        }

        if (!stopTimer)
        {
            min = Mathf.FloorToInt(timeCount / 60);
            sec = Mathf.FloorToInt(timeCount % 60);
            timer.text = string.Format("{0:0}:{1:00}", min, sec);
            timeSlider.value = timeCount;
        }

        
    }


}
