using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTuturialLevel()
    {

        SceneManager.LoadScene("Level0");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel1()
    {

        //SceneManager.LoadScene("Level1");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel2()
    {

        //SceneManager.LoadScene("Level2");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel3()
    {

        //SceneManager.LoadScene("Level3");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadLevel4()
    {

        SceneManager.LoadScene("Level4");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
