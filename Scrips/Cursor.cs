using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cursor : MonoBehaviour
{
    public Texture2D defaultTextureMouse;
    public Texture2D exitTextureMouse;
    public CursorMode curModeMouse = CursorMode.Auto;
    public Vector2 hotSpotMouse = Vector2.zero;

    // Use this for initialization
    void StartMouse()
    {
        UnityEngine.Cursor.SetCursor(defaultTextureMouse, hotSpotMouse, curModeMouse);
        
    }
    public void OnMouseEnter()
    {
        print(transform.name);
            UnityEngine.Cursor.SetCursor(exitTextureMouse, hotSpotMouse, curModeMouse);
        
    }
    public void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(defaultTextureMouse, hotSpotMouse, curModeMouse);
    }
}

