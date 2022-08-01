using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayTurnCommand playTurnCommand;
    SelectColor selectColor;
    UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        selectColor = FindObjectOfType<SelectColor>();
        uiController = FindObjectOfType<UIController>();
        playTurnCommand = new PlayTurnCommand(selectColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
