using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentSceneIndex;

    public float sceneLoadTime;

    public Button_UI playButton;
    public Button_UI quitButton;
    public Button_UI optionButton;
    public SoundsManager soundsManager;



    

    void Start()
    {
       

        
        soundsManager = FindObjectOfType<SoundsManager>();


        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        soundsManager.PlaySound("Music");

        playButton = GameObject.Find("StartButtonImage").GetComponent<Button_UI>();
        playButton.ClickFunc = () =>
        {
            Debug.Log("LOADGAMESIWA");
            Invoke("LoadGameScene", sceneLoadTime);

        };
        quitButton = GameObject.Find("QuitButtonImage").GetComponent<Button_UI>();
        quitButton.ClickFunc = () =>
        {
            Invoke("QuitGame", sceneLoadTime);
        };

        optionButton = GameObject.Find("OptionButtonImage").GetComponent<Button_UI>();
        optionButton.ClickFunc = () =>
        {
            Invoke("OptionScene", sceneLoadTime);
        };

        playButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        playButton.ClickFunc += () => { soundsManager.PlaySound("Click"); };

        optionButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        optionButton.ClickFunc += () => { soundsManager.PlaySound("Click"); };

        quitButton.MouseOverOnceFunc += () => { soundsManager.PlaySound("Hover"); };
        quitButton.ClickFunc += () => { soundsManager.PlaySound("ClickQuit"); };


    }
    private void Update()
    {
        
    }
    
       
           
              
            
        
    

    public void LevelComplete()
    {
       
        Invoke("LoadNextScene", sceneLoadTime);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Update is called once per frame
    void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void LoadGameScene()
    {
        
        SceneManager.LoadScene(2);
    }
    void OptionScene()
    {
        SceneManager.LoadScene(3);
    }

}
