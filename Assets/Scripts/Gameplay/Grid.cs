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

    public void PlaceTetramino(TetraminoView tetramino)
    {
        for (int i = 0; i < tetramino.Parts.Count; i++)
        {
            Cells[tetramino.Parts[i].PositionInGrid.y, tetramino.Parts[i].PositionInGrid.x].IsFill = true;
        }

        if (!game.IsEnded)
        {
            //новое тетрамино
        }
    }

    public GridCell GetCell(int x, int y)
    {
        return Cells[y, x];
    }
}
