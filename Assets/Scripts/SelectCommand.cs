using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : Command
{
    private SelectColor sc;

    public SelectCommand(SelectColor selectColor)
    {
        sc = selectColor;
    }

    public override void Execute()
    {
        if (sc.CurrentColor >= NewGrid.Instance.maxColors)
            sc.CurrentColor = NewGrid.Instance.maxColors - 1;

        if (sc.CurrentColor < 0)
            sc.CurrentColor = 0;

        sc.selectedColor[1].color = NewGrid.Instance.colorSelection[sc.CurrentColor];
        AdjacentColors();
    }

    void AdjacentColors()
    {
        int nextColor = sc.CurrentColor + 1;
        int previousColor = sc.CurrentColor - 1;

        if (nextColor < NewGrid.Instance.maxColors)
            sc.selectedColor[2].color = NewGrid.Instance.colorSelection[nextColor];
        else
        {
            sc.selectedColor[2].color = Color.clear;
        }

        if (previousColor >= 0)
            sc.selectedColor[0].color = NewGrid.Instance.colorSelection[previousColor];
        else
        {
            sc.selectedColor[0].color = Color.clear;
        }
    }

    public override void Undo()
    {
        return;
    }
}