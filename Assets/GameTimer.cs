using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Our Level time in seconds")]
    [SerializeField] public float levelTime = 10f;

    public Slider sliderValue;
    bool levelFinished;

    public GameObject winLabel;
    public GameObject lostLabel;


    // Update is called once per frame
    private void Start()
    {
        if (winLabel)
        {
            winLabel.SetActive(false);

        }
        if (lostLabel)
        {
            lostLabel.SetActive(false);

        }
        levelFinished = false;
        sliderValue = GetComponent<Slider>();
    }
    void Update()
    {
        if(levelFinished)
        {
            return;
        }

         sliderValue.value= Time.timeSinceLevelLoad / levelTime;

        bool timerFinished=(Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished&&FindObjectsOfType<EnemyInfo>().Length==0)
        {
            Debug.Log("TimeExpired");
            levelFinished = true;
            if (winLabel)
            {
                FindObjectOfType<SoundsManager>().StopMusic();
                FindObjectOfType<SoundsManager>().PlaySound("Finish");
                winLabel.SetActive(true);
                

            }
            //FindObjectOfType<SceneLoader>().LevelComplete();
        }
    }
}
