using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Модель объекта Тетромино. Работает сама по себе корректно, вне зависимости от системы координат Unity
/// </summary>
public class TetraminoCellModel : Cell
{
    public bool IsPlace { get; private set; }

    [SerializeField] private Vector2Int PositionRelativeCenter;
    
    private Tetramino parentTetramino;
    private Grid grid;

    public void Initialize(GridCell cell, Grid grid, Tetramino parentTetramino)
    {
        positionInGrid = cell.PositionInGrid + PositionRelativeCenter;
        this.grid = grid;
        this.parentTetramino = parentTetramino;
        IsPlace = false;
    }

    public void MoveLeft()
    {
        positionInGrid += new Vector2Int(-1, 0);
    }

    public void MoveRight()
    {
        positionInGrid += new Vector2Int(1, 0);
    }

    public void MoveDown()
    {
        positionInGrid += new Vector2Int(0, -1);
    }

    public void MoveUp()
    {
        positionInGrid += new Vector2Int(0, 1);
    }

    //90
    public void Rotate()
    {
        positionInGrid += new Vector2Int(PositionRelativeCenter.x * (-1), PositionRelativeCenter.y * (-1));

        if (PositionRelativeCenter.x < 0 || PositionRelativeCenter.x > 0)
        {
            PositionRelativeCenter.x *= -1;
        }
        (PositionRelativeCenter.x, PositionRelativeCenter.y) = (PositionRelativeCenter.y, PositionRelativeCenter.x);

        positionInGrid += new Vector2Int(PositionRelativeCenter.x, PositionRelativeCenter.y);
    }

    //-90
    public void RotateInverse()
    {
        positionInGrid += new Vector2Int(PositionRelativeCenter.x * (-1), PositionRelativeCenter.y * (-1));

        if (PositionRelativeCenter.y < 0 || PositionRelativeCenter.y > 0)
        {
            PositionRelativeCenter.y *= -1;
        }

        (PositionRelativeCenter.x, PositionRelativeCenter.y) = (PositionRelativeCenter.y, PositionRelativeCenter.x);

        positionInGrid += new Vector2Int(PositionRelativeCenter.x, PositionRelativeCenter.y);
    }

    public void MoveDownAfterClear()
    {
        if (parentTetramino != null)
        {
            parentTetramino.MoveDownAfterClear(this);
        }
    }

    public void DrawInGrid()
    {
        transform.position = grid.GetCell(PositionInGrid).transform.position;
    }

    public void Clear()
    {
        parentTetramino.ClearPart(this);
        Destroy(gameObject);
    }
}
