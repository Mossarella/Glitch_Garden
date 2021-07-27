using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesSpawner : MonoBehaviour
{
    public AllyInfo defender;
    public GameManager gameManager;
    public GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "DefendersGroup";

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        CreateDefenderParent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);

        if (!defenderParent)
        {


            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }
    
    public void SetSelectedDefender(AllyInfo defenderToSelect)
    {
        
        defender = defenderToSelect;
    }
    private void AttemptToPlaceDefenderAt(Vector2 pos)
    {
        if (!defender)
        {
            return;
        }



        int defenderCost = defender.GetStarCost();
        
        if(gameManager.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(pos);
            gameManager.DecreaseStar(defenderCost);
        }
    }

    private void OnMouseDown()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 worldPosSnap = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));

        AttemptToPlaceDefenderAt(worldPosSnap);
    }
    private void SpawnDefender(Vector2 mousePos)
    {
        AllyInfo newDefender = Instantiate(defender,mousePos, Quaternion.identity) as AllyInfo;
        newDefender.transform.SetParent(defenderParent.transform);

        defender = null;
        var buttons = FindObjectsOfType<AllyButton>();
        foreach (AllyButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(108, 108, 108, 255);
        }
    }
}
