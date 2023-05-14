using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
  
    void Start()
    {
        GetControl<Button>("Home").onClick.AddListener(() =>
        {

        });
        GetControl<Button>("Again").onClick.AddListener(() =>
        {

        });

    }
    void Update()
    {
        
    }
}
