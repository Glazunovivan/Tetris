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

        cells = new GridCellView[grid.Height, grid.Width];

        for (int y = 0; y < game.Height; y++)
        {
            for (int x = 0; x < game.Width; x++)
            {
                var inst = Instantiate(prefabCell, transform);
                inst.Initialize(grid.Cells[y,x]);
                inst.transform.localPosition = new Vector3(x, y, 0);
                cells[y, x] = inst;
            }
        }
    }

    public GridCellView GetCell(int x, int y)
    {
        return cells[y, x];
    }

    public void PlaceInGrid(TetraminoView tetramino)
    {
        for (int i = 0; i < tetramino.Parts.Count; i++)
        {
            AddInGrid(tetramino.Parts[i]);
        }

        if (!_game.IsEnded)
        {
            _game.NewTetramino();
        }
    }

    public void CheckLines()
    {
        for (int y = _grid.Height-1; y >= 0; y--)
        {
            if (IsRowFull(y))
            {
                ClearLine(y);
                Down(y);

                _game.UpdateScore();
            }
        }
    }

    private void ResetCells()
    {
        for (int y = 0; y < _grid.Height; y++)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                cells[y, x].IsFill = false;
            }
        }
    }

    private void AddInGrid(TetraminoCellView part)
    {
        //cells[part.PositionInGrid.y, part.PositionInGrid.x].IsFill = true;

        //сохраняем ссылку на часть тетромино, чтобы потом очистить клетку
        //cells[part.PositionInGrid.y, part.PositionInGrid.x].PartOfTetromino = part;
    }

    private bool IsRowFull(int y)
    {
        for (int x = 0; x < _game.Width; x++)
        {
            //if (cells[y, x].IsFill == false)
            //{
            //    return false;
            //}
        }
        return true;
    }

    private void ClearLine(int y)
    {
        for (int x = 0; x < _game.Width; x++)
        {
            //cells[y, x].IsFill = false;
            //Cells[y, x].PartOfTetromino.Clear();
        }
    }

    private void Down(int i)
    {
        for (int y = i; y < _game.Height; y++)
        {
            for (int x = 0; x < _game.Width; x++)
            {
                //if (Cells[y, x].IsFill)
                //{
                //    Cells[y - 1, x].IsFill = Cells[y, x].IsFill;
                //    Cells[y - 1, x].PartOfTetromino = Cells[y, x].PartOfTetromino;
                //    Cells[y, x].IsFill = false;
                //    Cells[y, x].PartOfTetromino = null;

                //    Cells[y-1, x].PartOfTetromino.MoveDownAfterClear();
                //}
            }
        }
    }
}
