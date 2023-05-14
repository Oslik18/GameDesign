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
    public int numberSources;
    private int min, sec;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI sourcesNumberUI;
    public Slider timeSlider;
    private float timeCount;
    public static bool stopTimer;
    public static int boom = 0;
    public GameObject panel;
    public GameObject button_again;
    public GameObject button_exit;
    public GameObject button_next;
    public static int sources;

    // Start is called before the first frame update
    void Start()
    {
        sources = numberSources;
        panel.SetActive(false);
        button_again.SetActive(false);
        button_exit.SetActive(false);
        button_next.SetActive(false);
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

        if (sources >= 0 )
        {
            sourcesNumberUI.text = sources.ToString();
        }
        

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
        button_again.SetActive(false);
    }

    void MenuAgain()
    {
        Time.timeScale = 0.0f;
        panel.SetActive(true);
        button_again.SetActive(true);
        button_exit.SetActive(true);
        button_next.SetActive(false);
    }


    public void LoadMenu()
    {
        
        if (PlayerMovement.player_destroy == 2)
        {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("Start");
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


}
