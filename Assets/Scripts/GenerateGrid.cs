//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GenerateGrid : MonoBehaviour
//{
//    private static ColorGrid instance;
//    public static ColorGrid Instance { get { return instance; } }

//    public Color[] colorSelection = new Color[8];

//    [Range(2, 24)]
//    public int size;

//    [Range(2, 8)]
//    public int maxColors;

//    public GameObject tileGO;

//    private float width;
//    private float height;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = new ColorGrid(size, maxColors);
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//            Destroy(this.gameObject);

//        for (int i = 0; i < colorSelection.Length; i++)
//            instance.SetColor(i, colorSelection[i]);

//        width = Camera.main.orthographicSize * (Camera.main.aspect * 1.25f);
//        height = Camera.main.orthographicSize * (Camera.main.aspect * 1.25f);

//        Generate();
//    }

//    void Generate()
//    {
//        float rectX = Camera.main.transform.position.x - width / 2;
//        float rectY = Camera.main.transform.position.y - height / 2;

//        float tileDistanceWidth = width / instance.Size;
//        float tileDistanceHeight = height / instance.Size;

//        Vector3 tileScale = new Vector3(tileDistanceWidth, tileDistanceHeight, 1);
//        tileGO.transform.localScale = tileScale;

//        #region Loop
//        for (int x = 0; x < instance.Size; x++)
//        {
//            for (int y = 0; y < instance.Size; y++)
//            {
//                Tile tile = instance.GetTile(x, y);

//                GameObject tileObject = Instantiate(tileGO,
//                    new Vector2(tile.GetX, tile.GetY),
//                    Quaternion.identity, this.transform);

//                tileObject.name = "Tile" + x + "_" + y;

//                tileObject.transform.position = new Vector3(
//                    tile.GetX * tileDistanceWidth + rectX + tileDistanceWidth / 2,
//                    tile.GetY * tileDistanceHeight + rectY + tileDistanceHeight / 2, 0);

//                SpriteRenderer tileRenderer = tileObject.GetComponent<SpriteRenderer>();
//                tileRenderer.color = colorSelection[tile.MyColor];

//                instance.SetTileObjects(tileObject, tile.GetX, tile.GetY);
//            }
//        }
//        #endregion
//    }
//}