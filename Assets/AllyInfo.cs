using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyInfo : MonoBehaviour
{
    public int starCost;
    public int maxHealth;
    public int currentHealth;

    public int starToAdd = 3;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public int GetStarCost()
    {
        return starCost;
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            Die();
        }
        else if (currentHealth - damage > 0)
        {

            currentHealth -= damage;
        }

    }
    void Die()
    {
        Destroy(this.gameObject);
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddStar()
    {
        FindObjectOfType<GameManager>().IncreaseStar(starToAdd);
        
    }
}
