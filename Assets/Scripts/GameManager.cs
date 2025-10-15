using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Initial Variable Values
    List<GameObject> Cards = new List<GameObject>();

    // Initial References
    [SerializeField] TextMeshProUGUI gameplayInstructions;
    ScoreZone scoreZone;

    public void Start()
    {
        // Should only work during the 'End' scene
        ShowPointsGameOver();
    }

    // Add the referenced card to the 'Cards' list
    public void AddCardToList(GameObject Card)
    {
        Cards.Add(Card);
    }

    // Destroy all cards in the 'Cards' list, and then clear it
    public void DestroyAllCards()
    {
        for (int i = Cards.Count - 1; i >= 0; i--)
        {
            Destroy(Cards[i]);
        }
        Cards.Clear();
    }

    // Function to get and display achieved score in 'End' scene
    // DO NOT USE OUTSIDE OF 'End' SCENE
    public void ShowPointsGameOver()
    {
        Debug.Log(scoreZone.scoreBanked);
        gameplayInstructions.text = "Final Score: " + scoreZone.scoreBanked; // <== Currently not working, perhaps unable to get value of 'scoreBanked'?
        Destroy(scoreZone);
    }

    // Behaviour for start and end menus
    public void MenuManager(string action)
    {
        switch (action)
        {
            // Start the game by switching to scene "Main" - [Any Scene]
            case "Start Game":
                SceneManager.LoadScene("Main");
                break;
            // Toggle display of gameplay instructions - [Start Scene]
            case "Toggle Instructions":
                if (gameplayInstructions.enabled)
                {
                    gameplayInstructions.enabled = false;
                }
                else
                {
                    gameplayInstructions.enabled = true;
                }
                break;
            // Go back to scene "Start" - [Any Scene]
            case "Restart Game":
                SceneManager.LoadScene("Start");
                break;
            // Close the game - [Any Scene]
            case "Quit Game":
                Application.Quit();
                break;
        }
    }
}
