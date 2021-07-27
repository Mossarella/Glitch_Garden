using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public AllyInfo defenderPrefab;
    void Start()
    {
        LabelButtonWithCost();
    }
    void LabelButtonWithCost()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = defenderPrefab.GetStarCost().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<AllyButton>();
        foreach (AllyButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(108, 108,108, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<AlliesSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
