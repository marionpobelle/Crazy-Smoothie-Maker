using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{

    public Texture2D defaultTexture;
    public Texture2D interactableTexture;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(defaultTexture, hotSpot, cursorMode);
    }

    void OnMouseEnter() 
    {
        if(gameObject.tag == "interactable")
        {
            Cursor.SetCursor(interactableTexture, hotSpot, cursorMode);
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotSpot, cursorMode);
    }
}
