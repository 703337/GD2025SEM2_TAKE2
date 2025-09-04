using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipOver : MonoBehaviour
{
    // Initial Variable Values
    bool isFlipped;
    bool isHovered;

    // Initial References
    [SerializeField] GameObject cardBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Flip card over
        if (Input.GetMouseButtonDown(1) && isHovered)
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

    public Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Function to flip card over
    private void FlipCard()
    {
        switch (isFlipped)
        {
            case false:
                isFlipped = true;
                cardBack.GetComponent<SpriteRenderer>().enabled = false;
                break;
            case true:
                isFlipped = false;
                cardBack.GetComponent<SpriteRenderer>().enabled = true;
                break;
        }
    }
}
