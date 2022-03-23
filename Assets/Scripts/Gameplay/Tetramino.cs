using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Tetramino : MonoBehaviour
{
    public enum TetraminoType
    {
        I, J, L, O, S, T, Z
    }

    private Grid grid;
    private Game game;

    [SerializeField] private TetraminoType type;
    [SerializeField] private List<TetraminoCellModel> parts;

    public bool IsPlaced { get; private set; }

    public List<TetraminoCellModel> Parts 
    { 
        get 
        { 
            return parts; 
        } 
    }

    public void Initialize(GridCell cell, Grid grid, Game game)
    {
        IsPlaced = false;
        this.grid = grid;
        this.game = game;
        game.OnGameStarted += DeleteTetramino;

        for (int i=0; i < Parts.Count; i++)
        {
            Parts[i].Create(cell, grid, this);
        }

        if (IsValidPosition()==false)
        {
            DeleteTetramino();
            game.GameOver();
            return;
        }

        DrawInGrid();
    }

    public void MoveLeft()
    {
        for (int i = 0; i < Parts.Count; i++)
        {
            Parts[i].MoveLeft();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].MoveRight();
            }
        }
        DrawInGrid();
    }

    public void MoveRight()
    {
        for (int i = 0; i < Parts.Count; i++)
        {
            Parts[i].MoveRight();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].MoveLeft();
            }
        }
        DrawInGrid();
    }

    public void MoveDown()
    {
        for (int i = 0; i < Parts.Count; i++)
        {
            Parts[i].MoveDown();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].MoveUp();
            }
            Place();
        }
        DrawInGrid();
    }

    public void MoveDownAfterClear(TetraminoCellModel part)
    {
        part.MoveDown();
        DrawInGrid();
    }

    public void Rotate()
    {
        if (type == TetraminoType.O)
        {
            return;
        }

        for (int i = 0; i < Parts.Count; i++)
        {
            Parts[i].Rotate();
        }

        if (IsValidPosition() == false)
        {
            //на левой половинке находимся
            //меняем положения, пока позиция не станет валидной
            if (Parts[0].PositionInGrid.x < grid.Width / 2)
            {
                do
                {
                    for (int i = 0; i < Parts.Count; i++)
                    {
                        Parts[i].RotateInverse();
                    }

                    for (int i = 0; i < Parts.Count; i++)
                    {
                        Parts[i].MoveRight();
                    }

                    Rotate();

                } while (IsValidPosition()!=true);
            }
            //на правой половинке находимся
            else if (Parts[0].PositionInGrid.x > grid.Width / 2)
            {
                do
                {
                    for (int i = 0; i < Parts.Count; i++)
                    {
                        Parts[i].RotateInverse();
                    }

                    for (int i = 0; i < Parts.Count; i++)
                    {
                        Parts[i].MoveLeft();
                    }

                    Rotate();

                } while (IsValidPosition()!=true);
            }
        }

        DrawInGrid();
    }

    public void ClearPart(TetraminoCellModel part)
    {
        parts.Remove(part);
        Destroy(part.gameObject);

        if (Parts.Count == 0)
        { 
            Destroy(gameObject);
        }
    }

    private bool IsValidPosition()
    {
        for (int i = 0; i < Parts.Count; i++)
        {
            if (Parts[i] != null)
            {
                if (Parts[i].PositionInGrid.x < 0 ||
                Parts[i].PositionInGrid.x >= grid.Width ||
                Parts[i].PositionInGrid.y < 0 ||
                Parts[i].PositionInGrid.y >= grid.Height)
                {
                    return false;
                }

                //проверка, занята ли клеточка с такими координатами
                if (grid.Cells[Parts[i].PositionInGrid.y, Parts[i].PositionInGrid.x].IsFill)
                {
                    return false;
                }
            }

        }
        return true;
    }

    private void DrawInGrid()
    {
        for (int i = 0; i < Parts.Count; i++)
        {
            if (Parts[i].gameObject != null)
            {
                Parts[i].DrawInGrid();
            }
        }
    }

    private void Place()
    {
        IsPlaced = true;
        grid.PlaceInGrid(this);
        grid.CheckLines();
    }

    private void DeleteTetramino()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        game.OnGameStarted -= DeleteTetramino;
    }
}
