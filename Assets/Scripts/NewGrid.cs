using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrid : MonoBehaviour
{
    private static NewGrid instance;
    public static NewGrid Instance { get { return instance; } }

    public ColorGrid colorGrid;

    public Color[] colorSelection = new Color[8];
    public Sprite sprite;

    [HideInInspector]
    public int size;

    [HideInInspector]
    public int maxColors;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GenerateGame(int newSize, int colors)
    {
        colorGrid = new ColorGrid(this, newSize, colors);
        maxColors = colors;
        size = newSize;
    }
}