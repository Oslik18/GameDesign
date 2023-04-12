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
    public GameObject panel;
    public GameObject button_again;
    public GameObject button_exit;
    public GameObject button_next;
    public GameObject button_spaceship;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        button_again.SetActive(false);
        button_exit.SetActive(false);
        button_next.SetActive(false);
        button_spaceship.SetActive(false);
        Count_tools count_tools = new Count_tools();
        count_tools.LoadFile();
        metal_sources = Count_tools.metal_all_sources;
        wood_sources = Count_tools.wood_all_sources;
        other_sources = Count_tools.other_all_sources;
        rocks_sources = Count_tools.rocks_all_sources;
        Time.timeScale = 1f;
        stopTimer = false;
        timeCount = minute * 60;
        timeSlider.maxValue = minute * 60;
        timeSlider.value = minute * 60;
    }

    void Update()
    {
        Timer();

        text_tools.text = other_sources.ToString();
        text_wood.text = wood_sources.ToString();
        text_metal.text = metal_sources.ToString();
        text_rocks.text = rocks_sources.ToString();

        if (PlayerMovement.player_destroy == 1)
        {
            Invoke("MenuAgain", 2f);
        }
        if (PlayerMovement.player_destroy == 2)
        {
            Invoke("MenuFinish", 0.8f);
        }
    }

    public void MenuFinish()
    {
        Time.timeScale = 0.0f;
        panel.SetActive(true);
        button_exit.SetActive(true);
        button_next.SetActive(true);
        button_spaceship.SetActive(true);
        button_again.SetActive(false);
    }

    public void MenuAgain()
    {
        Time.timeScale = 0.0f;
        panel.SetActive(true);
        button_again.SetActive(true);
        button_exit.SetActive(true);
        button_next.SetActive(false);
        button_spaceship.SetActive(false);
    }


    public void LoadMenu()
    {
        
        if (PlayerMovement.player_destroy == 2)
        {
            Count_tools count_tools = new Count_tools();
            count_tools.WriteFile(other_sources, metal_sources, wood_sources, rocks_sources);
            panel.SetActive(false);
        }

        SceneManager.LoadScene("Start");
    }


    public void LoadAgain()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Count_tools count_tools = new Count_tools();
        count_tools.WriteFile(other_sources, metal_sources, wood_sources, rocks_sources);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Timer()
    {
        timeCount -= Time.deltaTime;
        
        if (timeCount <= 0)
        {
            stopTimer = true;
            boom++;

        }

        if (!stopTimer)
        {
            min = Mathf.FloorToInt(timeCount / 60);
            sec = Mathf.FloorToInt(timeCount % 60);
            timer.text = string.Format("{0:0}:{1:00}", min, sec);
            timeSlider.value = timeCount;
        }

        
    }

    public void LoadSpaceship()
    {
        
    }

}
