using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI starDisplayText;
    public TextMeshProUGUI playerHealthDisplayText;

    public int currentStar;

    public int playerHealth;
    public int maxHealth;

    public SoundsManager soundManager;

    public bool gameOver=false;
    void Start()
    {
        soundManager = FindObjectOfType<SoundsManager>();
        soundManager.StopMusic();
        soundManager.PlaySound("Game");



        playerHealth = maxHealth;
        UpdateStarDisplay();
        UpdateHealthDisplay();
    }

    private void UpdateStarDisplay()
    {
        starDisplayText.text = currentStar.ToString();
        
    }
    void UpdateHealthDisplay()
    {
        playerHealthDisplayText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseStar(int starIncrease)
    {
        currentStar += starIncrease;
        UpdateStarDisplay();
    }
    public bool HaveEnoughStars(int amount)
    {
        return currentStar >= amount;
    }
    public void DecreaseStar(int starDecrease)
    {
        if (currentStar >= starDecrease)
        {


            currentStar -= starDecrease;
            UpdateStarDisplay();
        }
    }
    public void MaxHPReduce(int damage)
    {
        if (playerHealth - damage <= 0 && gameOver == false)
        {
            playerHealth = 0;
            UpdateHealthDisplay();
            GameOver();
        }
        else if (playerHealth - damage > 0)
        {
            playerHealth -= damage;
            UpdateHealthDisplay();
        }
    }
    public void GameOver()
    {
        gameOver = true;
        soundManager.StopMusic();
        soundManager.PlaySound("Failed");
        FindObjectOfType<GameTimer>().lostLabel.SetActive(true);
    }
}
