using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGrid
{
    GameObject[,] tileObjects;

    int size;
    public int Size { get { return size; } }

    public ColorGrid(NewGrid gng, int size = 6, int maxColors = 8)
    {
        this.size = size;
        tileObjects = new GameObject[size, size];

        float width = Camera.main.orthographicSize * (Camera.main.aspect * 1.25f);
        float height = Camera.main.orthographicSize * (Camera.main.aspect * 1.25f);

        float boundsX = Camera.main.transform.position.x - width / 2;
        float boundsY = Camera.main.transform.position.y - height / 2;

        float tileDistanceX = width / size;
        float tileDistanceY = height / size;

        Vector3 tileScale = new Vector3(tileDistanceX, tileDistanceY, 1);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                int colorIndex = Random.Range(0, maxColors);

                tileObjects[x, y] = new GameObject();
                tileObjects[x, y].name = ("Tile(" + x + ", " + y + ")");
                tileObjects[x, y].transform.localScale = tileScale;
                tileObjects[x, y].transform.position = new Vector3(
                    x * tileDistanceX + boundsX + tileDistanceX / 2,
                    y * tileDistanceY + boundsY + tileDistanceY / 2, 0);

                SpriteRenderer tileRenderer = tileObjects[x, y].AddComponent<SpriteRenderer>();
                tileRenderer.sprite = gng.sprite;
                tileRenderer.color = gng.colorSelection[colorIndex];

                MyTile tile = tileObjects[x, y].AddComponent<MyTile>();
                tile.ColorID = colorIndex;
                tile.Position = new Vector2(x, y);
            }
        }
    }

    public MyTile GetTile(int x, int y)
    {
        return tileObjects[x, y].GetComponent<MyTile>();
    }
}