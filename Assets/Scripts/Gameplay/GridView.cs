using System;
using UnityEngine;

public sealed class GridView : MonoBehaviour
{
    [SerializeField] private GridCellView prefabCell;

    private Game _game;
    private Grid _grid;

    private GridCellView[,] cells;

    public void Initialize(Game game, Grid grid)
    {
        _game = game;
        _game.OnGameStarted += ResetCells;
        _grid = grid;
        _grid.OnClear += ClearLine;
        _grid.OnDown += Down;

        cells = new GridCellView[grid.Height, grid.Width];

        for (int y = 0; y < _grid.Height; y++)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                var inst = Instantiate(prefabCell, transform);
                inst.Initialize(grid.Cells[y,x]);
                inst.transform.localPosition = new Vector3(x, y, 0);
                cells[y, x] = inst;
            }
        }
    }

    private void OnDestroy()
    {
        _game.OnGameStarted -= ResetCells;
        _grid.OnClear -= ClearLine;
        _grid.OnDown -= Down;
    }

    public GridCellView GetCell(int x, int y) => cells[y, x];

    public void PlaceTetramino(TetraminoView tetramino)
    {
        for (int i = 0; i < tetramino.Parts.Count; i++)
        {
            cells[tetramino.Parts[i].PositionInGrid.y, tetramino.Parts[i].PositionInGrid.x].PartOfTetromino = tetramino.Parts[i];
        }
    }

    private void Down(int i)
    {
        for (int y = i; y < _grid.Height-1; y++)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                cells[y, x].PartOfTetromino = cells[y+1, x].PartOfTetromino;
            }
        }
    }

    private void ResetCells()
    {
        for (int y = 0; y < _grid.Height; y++)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                cells[y, x].PartOfTetromino = null;
            }
        }
    }

    private void ClearLine(int y)
    {
        for (int x = 0; x < _grid.Width; x++)
        {
            if (cells[y,x].PartOfTetromino != null)
            {
                cells[y, x].PartOfTetromino.Clear();
            }
        }
    }
}
