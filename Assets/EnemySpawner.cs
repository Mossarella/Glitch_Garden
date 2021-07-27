using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] attackerPrefab;

    public int lane;
    // Start is called before the first frame update
    public int minInterval;
    public int maxInterval;

    public GameTimer gameTimer;
    
    bool spawn = true;

    
    private IEnumerator Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();

        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        GameObject currentEnemyInStantiate= Instantiate(attackerPrefab[Random.Range(0,attackerPrefab.Length)], transform.position, Quaternion.identity);

        currentEnemyInStantiate.transform.SetParent(this.gameObject.transform);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameTimer.sliderValue.value==1)
        {
            spawn = false;
        }
    }
}
