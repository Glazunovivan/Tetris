using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
    private Grid grid;

    [SerializeField] private TetraminoCellModel[] parts;

    public TetraminoCellModel[] Parts
    {
        get
        {
            return parts;
        }
    }

    public void Start()
    {
        grid = FindObjectOfType<Grid>();   
    }

    public void Initialize(Cell cell)
    {
        for (int i=0; i < parts.Length; i++)
        {
            parts[i].Initialize(cell);
        }
        DrawInGrid();
    }

    public void MoveLeft()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].MoveLeft();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].MoveRight();
            }
        }
        DrawInGrid();
    }

    public void MoveRight()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].MoveRight();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].MoveLeft();
            }
        }
        DrawInGrid();
    }

    public void MoveDown()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].MoveDown();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].MoveUp();
            }
        }
        DrawInGrid();
    }

    public void Rotate()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].Rotate();
        }
        
    }

    private bool IsValidPosition()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].PositionInGrid.x < 0 ||
                parts[i].PositionInGrid.x >= grid.Width ||
                parts[i].PositionInGrid.y < 0 ||
                parts[i].PositionInGrid.y >= grid.Height)
            {
                return false;
            }
        }
        return true;
    }


    private void DrawInGrid()
    {
        for (int i = 0; i < parts.Length;i++)
        {
            parts[i].transform.position = grid.GetCellPosition(parts[i].PositionInGrid);
        }
    }
}
