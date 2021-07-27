using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System;


public class OptionSceneManager : MonoBehaviour
{
    public float sceneLoadTime;

    public Button_UI backButton;
    public Button_UI defaultButton;

    public SoundsManager soundsManager;

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.6f;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();

        


        soundsManager = FindObjectOfType<SoundsManager>();

        backButton = GameObject.Find("BackButtonImage").GetComponent<Button_UI>();
        backButton.ClickFunc = () =>
        {
            SaveAndExit();
            Invoke("LoadMenuScene", sceneLoadTime);
        };

        backButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        backButton.ClickFunc += () => { soundsManager.PlaySound("Click"); };

        defaultButton = GameObject.Find("DefaultButtonImage").GetComponent<Button_UI>();
        defaultButton.ClickFunc = () =>
        {
            SetDefault();
            
        };

        defaultButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        defaultButton.ClickFunc += () => { soundsManager.PlaySound("Click"); };
    }

    // Update is called once per frame
    void Update()
    {
        soundsManager.SetVolume(volumeSlider.value);
    }
    void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);

    }
    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
    }
}
