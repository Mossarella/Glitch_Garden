using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource audiosource;


    public AudioClip hover;
    public AudioClip click;
    public AudioClip clickQuit;
    public AudioClip kazoo;
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip finish;
    public AudioClip failed;
    
    //public AudioClip shootSound;


    /*public enum soundState
    {
        0=flapSfx,
        1=scoreSfx,
        2=loseSfx,
        3=hoverSfx,
        4=clickSfx,
    }*/
    void Start()
    {
        audiosource.GetComponent<AudioSource>();

       
    }
    public void SetVolume(float volume)
    {
        audiosource.volume = volume;
    }
    // Update is called once per frame
    public void PlaySound(string soundState)
    {
        switch (soundState)
        {

            case "Hover":
                audiosource.PlayOneShot(hover);
                break;
            case "Click":
                audiosource.PlayOneShot(click);
                break;
            case "ClickQuit":
                audiosource.PlayOneShot(clickQuit);
                break;
            case "Kazoo":
                audiosource.PlayOneShot(kazoo);
                break;
            case "Music":
                audiosource.clip = menuMusic;
                audiosource.Play();
                break;
            case "Game":
                audiosource.clip = gameMusic;
                audiosource.Play();
                break;
            case "Finish":
                audiosource.PlayOneShot(finish);
                break;
            case "Failed":
                audiosource.PlayOneShot(failed);
                break;

            default:
                break;

        }

    }
    public void StopMusic()
    {
        audiosource.Stop();
    }
}
