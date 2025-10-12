using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardBehaviour : MonoBehaviour
{
    // Initial Variable Values
    bool isDragging;
    bool isHovered;
    [SerializeField] public bool isFlipped;
    public bool flippable;
    public bool justFlipped;
    Vector3 mousePositionOffset;
    [SerializeField] public int cardValue;
    public int GetCardValue()
    {
        if (isFlipped == false)
        {
            return 0;
        }
        return cardValue;
    }

    // Initial References
    [SerializeField] GameObject cardBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right);
    }

    // Update is called once per frame
    void Update()
    {
        // Drag around object
        if (Input.GetMouseButtonDown(0) && isHovered)
        {
            DragCard();
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            DragCard();
            isDragging = true;
        }
        else
        {
            isDragging = false;
        }
        // Flip card over
        if (Input.GetMouseButtonDown(1) && isHovered && flippable)
        {
            FlipCard();
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

    // Get the mouse position in relation to the object within the world
    public Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDown()
    {
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    // Function to drag card around
    private void DragCard()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    // Function to flip card over
    private void FlipCard()
    {
        switch (isFlipped)
        {
            case false:
                isFlipped = true;
                cardBack.GetComponent<SpriteRenderer>().enabled = false;
                justFlipped = true;
                break;
            case true:
                isFlipped = false;
                cardBack.GetComponent<SpriteRenderer>().enabled = true;
                justFlipped = true;
                break;
        }
    }

    public void DestoryCard()
    {
        Destroy(gameObject);
    }
}
