using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ScoreZone : MonoBehaviour
{
    // Initial Variable Values
    int score;
    public int scoreBanked;
    int lives = 3;
    bool pauseStayFunc;

    // Initial References
    [SerializeField] GameManager gameManager;
    [SerializeField] Button ScoreBanker;
    [SerializeField] TextMeshProUGUI LifeCounter;
    [SerializeField] TextMeshProUGUI BankedScoreCounter;
    [SerializeField] TextMeshProUGUI ScoreCounter;

    public List<CardBehaviour> cardLists = new List<CardBehaviour>();

    public int testAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckCards()
    {
        score = 0;

        foreach(CardBehaviour card in cardLists)
        {
            if(card.isFlipped == true)
            {
                score += card.cardValue;
            }
        }

        ScoreCounter.text = "Score: " + score;
    }

    // Function to add card values to total score
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<CardBehaviour>() != null)
        {
            CardBehaviour card = other.GetComponent<CardBehaviour>();
            card.ZoneEntered();
            cardLists.Add(card);
            CheckCards();
        }

        return;

        // Allow cards to flip
        other.GetComponentInParent<CardBehaviour>().flippable = true;
        // Add to score
        score += other.GetComponentInParent<CardBehaviour>().GetCardValue();
        // Display score text
        ScoreCounter.text = "Score: " + score;
        // Alter score text colour
        if (score == 21)
        {
            ScoreCounter.color = Color.green;
        }
        else if (score > 21)
        {
            ScoreCounter.color = Color.red;
            StartCoroutine(LoseLife());
            pauseStayFunc = true;
        }
        else
        {
            ScoreCounter.color = Color.white;
        }
        // Enable score banking above 16
        if (score >= 16)
        {
            ScoreBanker.interactable = true;
        }
        else
        {
            ScoreBanker.interactable = false;
        }
    }

    // Function to alter score based on card flip state < ------------ DO THIS PROPERLY ------------ <
    void OnTriggerStay2D(Collider2D other)
    {
        return;

        // Alter score
        if (other.GetComponentInParent<CardBehaviour>().isFlipped == false && other.GetComponentInParent<CardBehaviour>().justFlipped == true)
        {
            score -= other.GetComponentInParent<CardBehaviour>().cardValue;
            other.GetComponentInParent<CardBehaviour>().justFlipped = false;
        }
        else if (other.GetComponentInParent<CardBehaviour>().isFlipped == true && other.GetComponentInParent<CardBehaviour>().justFlipped == true)
        {
            score += other.GetComponentInParent<CardBehaviour>().cardValue;
            other.GetComponentInParent<CardBehaviour>().justFlipped = false;
        }
        // Display score text
        if (pauseStayFunc == true)
        {
            return;
        }
        ScoreCounter.text = "Score: " + score;
        // Alter score text colour
        if (score == 21)
        {
            ScoreCounter.color = Color.green;
        }
        else if (score > 21)
        {
            ScoreCounter.color = Color.red;
            StartCoroutine(LoseLife());
            pauseStayFunc = true;
        }
        else
        {
            ScoreCounter.color = Color.white;
        }
        // Enable score banking above 16
        if (score >= 16)
        {
            ScoreBanker.interactable = true;
        }
        else
        {
            ScoreBanker.interactable = false;
        }
    }

    // Function to add card values to total score
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<CardBehaviour>() != null)
        {
            CardBehaviour card = other.GetComponent<CardBehaviour>();
            card.ZoneExited();
            cardLists.Remove(card);
            CheckCards();
        }

        return;

        // Disallow cards to flip
        other.GetComponentInParent<CardBehaviour>().flippable = false;
        // Subtract from score
        score -= other.GetComponentInParent<CardBehaviour>().GetCardValue();
        // Display score text
        ScoreCounter.text = "Score: " + score;
        // Alter score text colour
        if (score == 21)
        {
            ScoreCounter.color = Color.green;
        }
        else if (score > 21)
        {
            ScoreCounter.color = Color.red;
            StartCoroutine(LoseLife());
            pauseStayFunc = true;
        }
        else
        {
            ScoreCounter.color = Color.white;
        }
        // Enable score banking above 16
        if (score >= 16)
        {
            ScoreBanker.interactable = true;
        }
        else
        {
            ScoreBanker.interactable = false;
        }
    }

    // Function to bank score
    public void BankScore()
    {
        // Bank and display score
        scoreBanked += score;
        BankedScoreCounter.text = "Banked Score: " + scoreBanked;
        // Reset score and clear cards
        ScoreBanker.interactable = false;
        gameManager.DestroyAllCards();
        score = 0;
        ScoreCounter.text = "Score: " + score;
        ScoreCounter.color = Color.white;
    }

    // Function to lose a life and clear cards
    IEnumerator LoseLife()
    {
        // Subtract a life
        lives -= 1;
        LifeCounter.text = "Lives: " + lives;
        // Wait on a timer before resetting score and clearing cards
        ScoreBanker.interactable = false;
        yield return new WaitForSecondsRealtime(1);
        gameManager.DestroyAllCards();
        score = 0;
        ScoreCounter.text = "Score: " + score;
        ScoreCounter.color = Color.white;
        pauseStayFunc = false;
        // End the game if all lives are lost
        if (lives == 0)
        {
            SceneManager.LoadScene("End");
            DontDestroyOnLoad(gameObject);
            gameObject.GetComponentInChildren<TilemapRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
