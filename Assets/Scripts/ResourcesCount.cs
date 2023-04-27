using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourcesCount : MonoBehaviour
{
    public int metal_all_sources = 0;
    public int wood_all_sources = 0;
    public int other_all_sources = 0;
    public int rocks_all_sources = 0;
    public static ResourcesCount instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    

}
