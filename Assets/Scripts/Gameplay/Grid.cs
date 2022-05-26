using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int Width;
    public int Height;

    public GridCell[,] Cells;
    private Game game;

    public Grid(int width, int height, Game game)
    {
        Width = width;
        Height = height;

        Cells = new GridCell[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Cells[y, x] = new GridCell(x,y);
            }
        }
    }

    public void PlaceTetramino(Tetramino tetramino)
    {
        for (int i = 0; i < tetramino.Parts.Length; i++)
        {
            Cells[tetramino.Parts[i].GridY, tetramino.Parts[i].GridX].IsFill = true;
        }

        //if (!game.IsEnded)
        //{
        //    //новое тетрамино
        //}
    }

    public void CheckLines()
    {
        for (int y = Height - 1; y >= 0; y--)
        {
            if (IsRowFull(y))
            {
                ClearLine(y);
                Down(y);

                //_game.UpdateScore();
            }
        }
    }

    private bool IsRowFull(int y)
    {
        for (int x = 0; x < Width; x++)
        {
            if (Cells[y, x].IsFill == false)
            {
                return false;
            }
        }
        return true;
    }

    private void ClearLine(int y)
    {
        for (int x = 0; x <Width; x++)
        {
            Cells[y, x].IsFill = false;
            //Cells[y, x].PartOfTetromino.Clear();
        }
    }

    private void Down(int i)
    {
        for (int y = i; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (Cells[y, x].IsFill)
                {
                    Cells[y - 1, x].IsFill = Cells[y, x].IsFill;
                    Cells[y - 1, x].PartOfTetromino = Cells[y, x].PartOfTetromino;
                    Cells[y, x].IsFill = false;
                    Cells[y, x].PartOfTetromino = null;

                    //Cells[y - 1, x].PartOfTetromino.MoveDownAfterClear();
                }
            }
        }
    }

    public GridCell GetCell(int x, int y)
    {
        return Cells[y, x];
    }
}
