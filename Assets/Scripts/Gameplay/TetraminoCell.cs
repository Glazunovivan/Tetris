using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Частичка тетромино
/// </summary>
public class TetraminoCell
{
    public Vector2Int PositionRelativeCenter { get; set; }

    public int GridX;
    public int GridY;

    public Vector2Int PositionInGrid { get; set; }

    public TetraminoCell(int x, int y)
    {
        PositionRelativeCenter = new Vector2Int(x, y);
    }

    public void MoveLeft()
    {
        GridX += -1;
    }

    public void MoveRight()
    {
        GridX += 1;
    }

    public void MoveDown()
    {
        GridY += -1;
    }

    public void MoveUp()
    {
        GridY +=1;
    }
}
