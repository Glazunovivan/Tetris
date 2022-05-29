using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Частичка тетромино
/// </summary>
public class TetraminoCell
{
    public Vector2Int PositionRelativeCenter
    {
        get
        {
            return positionRelativeCenter;
        }
    }

    private Vector2Int positionRelativeCenter;

    public int GridX;
    public int GridY;

    public event Action OnDown;

    public Tetramino Tetramino;

    public TetraminoCell(int x, int y, Tetramino tetramino)
    {
        Tetramino = tetramino;
        positionRelativeCenter = new Vector2Int(x, y);
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
        GridY -= 1;
    }

    public void MoveUp()
    {
        GridY +=1;
    }

    /// <summary>
    /// Поворачиваем клетку в 90
    /// </summary>
    public void Rotate()
    {
        GridX += positionRelativeCenter.x * (-1);
        GridY += positionRelativeCenter.y * (-1);

        if (positionRelativeCenter.x < 0 || positionRelativeCenter.x > 0)
        {
            positionRelativeCenter.x *= -1;
        }

        (positionRelativeCenter.x, positionRelativeCenter.y) = (positionRelativeCenter.y, positionRelativeCenter.x);

        GridX += positionRelativeCenter.x;
        GridY += positionRelativeCenter.y;
    }

    /// <summary>
    /// Поворачиваем клеточку в -90
    /// </summary>
    public void RotateInverse()
    {
        GridX += positionRelativeCenter.x * (-1);
        GridY += positionRelativeCenter.y * (-1);

        if (positionRelativeCenter.y < 0 || positionRelativeCenter.y > 0)
        {
            positionRelativeCenter.y *= -1;
        }
        GridX += positionRelativeCenter.x;
        GridY += positionRelativeCenter.y;
    }

    public void MoveDownAfterClear()
    {
        MoveDown();
        OnDown?.Invoke();
    }
}
