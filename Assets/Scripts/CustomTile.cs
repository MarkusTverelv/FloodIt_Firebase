using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "Custom", order = 1)]
public class CustomTile : ScriptableObject
{
    public Vector3 position = Vector3.zero;
    public string tileName = "NewTile";
    public Color myColor = Color.white;
    public int colorId = -1;
    public bool isConquered = false;
}
