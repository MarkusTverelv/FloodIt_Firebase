using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayerStats : MonoBehaviour
{
    public void OtherPlayersButton()
    {
        SceneLoader.SceneInstance.GoToLevel("HighScores");
    }
}
