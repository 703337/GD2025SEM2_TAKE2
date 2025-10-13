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

    public void AddCardToList(GameObject Card)
    {
        Cards.Add(Card);
    }

    public void DestroyAllCards()
    {
        for (int i = Cards.Count - 1; i >= 0; i--)
        {
            Destroy(Cards[i]);
        }
        Cards.Clear();
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
