using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public SoundsManager soundsManager;
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
       

        
            soundsManager.PlaySound("Kazoo");
            Invoke("LoadMenuScene", 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
