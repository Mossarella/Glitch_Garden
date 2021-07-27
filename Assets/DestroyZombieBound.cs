using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZombieBound : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.MaxHPReduce(1);
            Debug.Log("FUCKFUCKFUCK");
            Destroy(other.gameObject);
        }
    }
}
