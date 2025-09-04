using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAround : MonoBehaviour
{
    // Initial Variable Values
    bool isDragging;
    bool isHovered;
    Vector3 mousePositionOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    public void OnMouseDown()
    {
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    // Function to drag card around
    private void DragCard()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
}
