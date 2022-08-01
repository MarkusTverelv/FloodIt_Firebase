using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreProcentageText;
    public TextMeshProUGUI triesText;
    public TextMeshProUGUI nicknameText;

    private void Start()
    {
        if (PlayerData.data.myName != null)
            nicknameText.text = PlayerData.data.myName;
        else
            nicknameText.text = string.Empty;
    }

    public void UpdateScoreProcentage(float procentage)
    {
        scoreProcentageText.text = procentage.ToString() + "%";
    }

    public void UpdateTurns(int tries)
    {
        triesText.text = tries.ToString();
    }
}