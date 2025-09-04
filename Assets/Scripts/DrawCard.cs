using System;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    // Initial Variable Values
    bool isHovered;

    // Initial References
    [SerializeField] GameObject Red2;
    [SerializeField] GameObject Black2;
    [SerializeField] GameObject RedJoker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Draw card
        if (Input.GetMouseButtonDown(1) && isHovered)
        {
            DrawCards();
        }
    }

    // Function triggered when mouse enters trigger volume
    public void OnMouseEnter()
    {
        isHovered = true;
    }

    // Function triggered when mouse exits trigger volume
    public void OnMouseExit()
    {
        isHovered = false;
    }

    public void DrawCards()
    {
        GameObject pickedCard;
        int pickedCardInt = UnityEngine.Random.Range(0, 54);
        switch (pickedCardInt)
        {
            case 0:
                pickedCard = Red2;
                break;
            case 1:
                pickedCard = Black2;
                break;
            default:
                pickedCard = RedJoker;
                break;
        }
        Instantiate<GameObject>(pickedCard, transform);
    }
}
