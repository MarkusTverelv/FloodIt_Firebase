using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectColor : MonoBehaviour
{
    public Image[] selectedColor;

    private MyTile[,] conqueredTiles;
    private UIController uic;
    private ColorGrid grid;

    private int currentColor;
    private float conqueredTilesAmount;
    private int turns;

    public int CurrentColor { get { return currentColor; } set { currentColor = value; } }

    private void Start()
    {
        uic = FindObjectOfType<UIController>();
        grid = NewGrid.Instance.colorGrid;

        conqueredTiles = new MyTile[grid.Size, grid.Size];
        currentColor = 0;
        conqueredTilesAmount = 0;
        turns = 1;

        // Set starting tile to be conquered at start
        conqueredTiles[0, grid.Size - 1] = grid.GetTile(0, grid.Size - 1);
    }

    public void ChangeColors()
    {
        int newColor = currentColor;

        for (int x = 0; x < conqueredTiles.GetLength(0); x++)
            for (int y = conqueredTiles.GetLength(1) - 1; y >= 0; y--)
                if (conqueredTiles[x, y] != null)
                    CheckConnectingTiles(conqueredTiles[x, y], newColor);

        if (GetControlPercentage() < 100)
        {
            uic.UpdateTurns(turns++);
            PlayerData.data.tries++;
            PlayerData.SaveData();
        }
        else
        {
            PlayerData.data.tries = 0;
        }

        StartCoroutine(UpdateColors(newColor));
        uic.UpdateScoreProcentage(GetControlPercentage());
    }

    private void CheckConnectingTiles(MyTile tile, int colorIndex)
    {
        // Right Tile
        if ((int)tile.Position.x < grid.Size - 1)
        {
            if (colorIndex == NearbyTile(tile, 1, 0).ColorID)
                conqueredTiles[(int)tile.Position.x + 1,
                    (int)tile.Position.y] = NearbyTile(tile, 1, 0);
        }
        // Left Tile
        if ((int)tile.Position.x > 0)
        {
            if (colorIndex == NearbyTile(tile, -1, 0).ColorID)
                conqueredTiles[(int)tile.Position.x - 1,
                    (int)tile.Position.y] = NearbyTile(tile, -1, 0);
        }
        // Top Tile
        if ((int)tile.Position.y < grid.Size - 1)
        {
            if (colorIndex == NearbyTile(tile, 0, 1).ColorID)
                conqueredTiles[(int)tile.Position.x,
                    (int)tile.Position.y + 1] = NearbyTile(tile, 0, 1);
        }
        // Bottom Tile
        if ((int)tile.Position.y > 0)
        {
            if (colorIndex == NearbyTile(tile, 0, -1).ColorID)
                conqueredTiles[(int)tile.Position.x,
                    (int)tile.Position.y - 1] = NearbyTile(tile, 0, -1);
        }
    }

    private MyTile NearbyTile(MyTile currentTile, int offsetX, int offsetY)
    {
        return grid.GetTile((int)currentTile.Position.x + offsetX,
            (int)currentTile.Position.y + offsetY);
    }

    private IEnumerator UpdateColors(int newColor)
    {
        for (int x = 0; x < conqueredTiles.GetLength(0); x++)
            for (int y = conqueredTiles.GetLength(1) - 1; y >= 0; y--)
            {
                if (conqueredTiles[x, y] != null)
                {
                    yield return new WaitForSeconds(.005f);
                    grid.GetTile(x, y).SetColor(newColor);
                }
            }
    }

    public float GetControlPercentage()
    {
        int tmp = 0;

        for (int i = 0; i < conqueredTiles.GetLength(0); i++)
            for (int j = 0; j < conqueredTiles.GetLength(1); j++)
                if (conqueredTiles[i, j] != null)
                    conqueredTilesAmount = tmp++;

        return Mathf.Round((conqueredTilesAmount / (grid.Size * grid.Size)) * 100 + .5f);
    }
}