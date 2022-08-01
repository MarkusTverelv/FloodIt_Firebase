using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTile: MonoBehaviour
{
    public int colorID;

    Vector2 position;

    SpriteRenderer spriteRenderer;
    readonly NewGrid newGrid = NewGrid.Instance;

    public int ColorID { get { return colorID; } set { colorID = value; } }
    public Vector2 Position { get => position; set => position = value; }

    public void SetColor(int index)
    {
        int savedIndex = index;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = newGrid.colorSelection[savedIndex];
    }
}