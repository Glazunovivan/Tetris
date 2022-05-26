using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public GridCell[,] Cells { get; private set; }

    private Game _game;

    public Grid(int width, int height, Game game)
    {
        Width = width;
        Height = height;
        
        _game = game;

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
            //��������� ������ �� ����� ���������, ����� ����� �������� ������
            Cells[tetramino.Parts[i].GridY, tetramino.Parts[i].GridX].PartOfTetromino = tetramino.Parts[i];
        }

        if (!_game.IsEnded)
        {
            _game.NewTetramino();
        }
    }

    public void CheckLines()
    {
        for (int y = Height - 1; y >= 0; y--)
        {
            if (IsRowFull(y))
            {
                ClearLine(y);
                Down(y);

                _game.UpdateScore();
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
            Cells[y, x].PartOfTetromino = null;
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
                }
            }
        }
    }

    public GridCell GetCell(int x, int y) => Cells[y, x];
}
