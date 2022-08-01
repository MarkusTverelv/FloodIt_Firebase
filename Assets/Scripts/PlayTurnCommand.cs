using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTurnCommand : Command
{
    private SelectColor colorSelect;

    public PlayTurnCommand(SelectColor selectColor)
    {
        colorSelect = selectColor;
    }

    public override void Execute()
    {
        // Save the colorID from all conqueredTiles
        colorSelect.ChangeColors();
    }

    public override void Undo()
    {
        // Load the colorID to recent conqueredTiles
        return;
    }
}