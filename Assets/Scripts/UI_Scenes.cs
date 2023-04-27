using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

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
    private GameObject resourceCount;
    private ResourcesCount value;

    // Start is called before the first frame update
    void Start()
    {
        resourceCount = GameObject.Find("ResourcesCount");
        value = resourceCount.GetComponent<ResourcesCount>();
        panel.SetActive(false);
        button_again.SetActive(false);
        button_exit.SetActive(false);
        button_next.SetActive(false);
        button_spaceship.SetActive(false);
        LoadSources();
        Time.timeScale = 1f;
        stopTimer = false;
        timeCount = minute * 60;
        timeSlider.maxValue = minute * 60;
        timeSlider.value = minute * 60;
        GameObject.Find("Background").GetComponent<Image>().color = new Color32(137, 81, 81, 255);
        
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
            Invoke("MenuAgain", 1.7f);
        }
        if (PlayerMovement.player_destroy == 2)
        {
            Invoke("MenuFinish", 0.8f);
        }
    }

    void MenuFinish()
    {
        Time.timeScale = 0.0f;
        panel.SetActive(true);
        button_exit.SetActive(true);
        button_next.SetActive(true);
        button_spaceship.SetActive(true);
        button_again.SetActive(false);
    }

    void MenuAgain()
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
            value.other_all_sources = other_sources;
            value.metal_all_sources = metal_sources;
            value.wood_all_sources = wood_sources;
            value.rocks_all_sources = rocks_sources;
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
        value.other_all_sources = other_sources;
        value.metal_all_sources = metal_sources;
        value.wood_all_sources = wood_sources;
        value.rocks_all_sources = rocks_sources;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Start");
    }

    void Timer()
    {
        timeCount -= Time.deltaTime;

        if (timeCount <= 10)
        {
            GameObject.Find("Background").GetComponent<Image>().color = new Color32(224, 202, 69, 255);
        }

        

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

    public void LoadSources()
    {
        other_sources = value.other_all_sources;
        metal_sources = value.metal_all_sources;
        wood_sources = value.wood_all_sources;
        rocks_sources = value.rocks_all_sources;


    }

}
