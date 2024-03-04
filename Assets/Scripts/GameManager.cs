using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string bottleTag = "Beer";
    private int remainingBottleCount;

    public TextMeshProUGUI beerCounterText;

    public static GameManager gameManager;
    public GameObject winPanel;
    private void Awake()
    {
        //Singleton
        gameManager = this;

        //Disable panel on begining
        winPanel.SetActive(false);
    }
    void Start()
    {
        CalculateInitialBottleCount();
        UpdateBeerCounterText();
    }

    private void CalculateInitialBottleCount()
    {
        // Find all GameObjects with the specified tag
        GameObject[] bottles = GameObject.FindGameObjectsWithTag(bottleTag);

        // Set the initial bottle count based on the number of bottles found
        remainingBottleCount = bottles.Length;
    }
    private void UpdateBeerCounterText()
    {
        beerCounterText.text = "Beer Bottles: " + remainingBottleCount;
    }
    public void DecrementBottleCount()
    {
        if (remainingBottleCount > 0)
        {
            remainingBottleCount--;
            UpdateBeerCounterText();

            if (remainingBottleCount == 0)
            {
                winPanel.SetActive(true);
            }
        }
    }
}
