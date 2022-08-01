using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveGames : MonoBehaviour
{
    public TMP_Dropdown activeGamesList;

    public void UpdateList()
    {
        if (PlayerData.data.activeGames != null)
        {
            activeGamesList.AddOptions(PlayerData.data.activeGames);
        }
    }
}
