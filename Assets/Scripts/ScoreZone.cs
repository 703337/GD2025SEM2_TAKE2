using System;
using TMPro;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    // Initial Variable Values
    int score;

    // Initial References
    [SerializeField] TextMeshProUGUI ScoreCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to add card values to total score
    void OnTriggerEnter2D(Collider2D other)
    {
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
        }
        else
        {
            ScoreCounter.color = Color.white;
        }
    }

    // Function to alter score based on card flip state < ------------ DO THIS PROPERLY ------------ <
    void OnTriggerStay2D(Collider2D other)
    {
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
        ScoreCounter.text = "Score: " + score;
        // Alter score text colour
        if (score == 21)
        {
            ScoreCounter.color = Color.green;
        }
        else if (score > 21)
        {
            ScoreCounter.color = Color.red;
        }
        else
        {
            ScoreCounter.color = Color.white;
        }
    }

    // Function to add card values to total score
    void OnTriggerExit2D(Collider2D other)
    {
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
        }
        else
        {
            ScoreCounter.color = Color.white;
        }
    }
}
