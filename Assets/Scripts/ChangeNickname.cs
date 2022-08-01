using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNickname : MonoBehaviour
{
    public TMP_InputField nickname;

    private void Start()
    {
        nickname.onEndEdit.AddListener((ChangeNickname) => Change(nickname.text));

        if (PlayerData.data.myName != null)
            nickname.text = PlayerData.data.myName;
        else
            nickname.text = string.Empty;
    }
    private void Change(string newName)
    {
        newName = nickname.text;
        PlayerData.data.myName = newName;
        PlayerData.SaveData();
    }
}
