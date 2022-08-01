using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI gamesPlayed;

    public void DisplayStats(string name, int games)
    {
        userName.text = name;
        gamesPlayed.text = games.ToString();
    }
}