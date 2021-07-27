using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System;
public class GameOver : MonoBehaviour
{
    public Button_UI retryButton;
    public Button_UI menuButton;
    public SoundsManager soundsManager;

    public float sceneLoadTime;

    void Start()
    {

        soundsManager = FindObjectOfType<SoundsManager>();

        

        
        retryButton.ClickFunc = () =>
        {
            Invoke("ReloadThisScene", sceneLoadTime);

        };
      
        menuButton.ClickFunc = () =>
        {
            Invoke("LoadMenuScene", sceneLoadTime);
        };

        retryButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        retryButton.ClickFunc += () => { soundsManager.PlaySound("Click"); };

        menuButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        menuButton.ClickFunc += () => { soundsManager.PlaySound("ClickQuit"); };
    }

    // Update is called once per frame
    void ReloadThisScene()
    {
        Debug.Log("LOADSIWA");
        SceneManager.LoadScene(2);
    }
    void LoadMenuScene()
    {
        Debug.Log("MENUSIWA");
        SceneManager.LoadScene(1);
    }
}
