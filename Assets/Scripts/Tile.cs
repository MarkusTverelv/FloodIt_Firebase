using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    ColorGrid grid;

    int x;
    int y;

    int myColor;

    bool isConquered;

    public int GetX { get { return x; } }
    public int GetY { get { return y; } }
    public int MyColor { get { return myColor; } set { myColor = value; } }
    public bool Conquered { get { return isConquered; } set { isConquered = value; } }

    public Tile(ColorGrid grid, int x, int y, int newColor)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        myColor = newColor;
        isConquered = false;
    }
}
