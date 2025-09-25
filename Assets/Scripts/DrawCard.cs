using System;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    // Initial Variable Values
    bool isHovered;

    // Initial References
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject Red2;
    [SerializeField] GameObject Black2;
    [SerializeField] GameObject Red3;
    [SerializeField] GameObject Black3;
    [SerializeField] GameObject Red4;
    [SerializeField] GameObject Black4;
    [SerializeField] GameObject Red5;
    [SerializeField] GameObject Black5;
    [SerializeField] GameObject Red6;
    [SerializeField] GameObject Black6;
    [SerializeField] GameObject Red7;
    [SerializeField] GameObject Black7;
    [SerializeField] GameObject Red8;
    [SerializeField] GameObject Black8;
    [SerializeField] GameObject Red9;
    [SerializeField] GameObject Black9;
    [SerializeField] GameObject Red10;
    [SerializeField] GameObject Black10;
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
        int pickedCardInt = UnityEngine.Random.Range(0, 17);
        switch (pickedCardInt)
        {
            case 0:
                pickedCard = Red2;
                break;
            case 1:
                pickedCard = Black2;
                break;
            case 2:
                pickedCard = Red3;
                break;
            case 3:
                pickedCard = Black3;
                break;
            case 4:
                pickedCard = Red4;
                break;
            case 5:
                pickedCard = Black4;
                break;
            case 6:
                pickedCard = Red5;
                break;
            case 7:
                pickedCard = Black5;
                break;
            case 8:
                pickedCard = Red6;
                break;
            case 9:
                pickedCard = Black6;
                break;
            case 10:
                pickedCard = Red7;
                break;
            case 11:
                pickedCard = Black7;
                break;
            case 12:
                pickedCard = Red8;
                break;
            case 13:
                pickedCard = Black8;
                break;
            case 14:
                pickedCard = Red9;
                break;
            case 15:
                pickedCard = Black9;
                break;
            case 16:
                pickedCard = Red10;
                break;
            case 17:
                pickedCard = Black10;
                break;
            default:
                pickedCard = RedJoker;
                break;
        }
        GameObject spawnCard = Instantiate<GameObject>(pickedCard, transform);
        gameManager.AddCardToList(spawnCard);
    }
}
