using UnityEngine;

public sealed class GridView : MonoBehaviour
{
    public readonly int Width = 10;
    public readonly int Height = 20;

    [SerializeField] private GridCellView prefabCell;

    private GridCellView[,] cells;
    private Game game;
    
    public GridCellView[,] Cells
    {
        get
        {
            return cells;
        }
    }

    public void Initialize(Game game)
    {
        this.game = game;
        this.game.OnGameStarted += ResetCells;

        cells = new GridCellView[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                var instantiate = Instantiate(prefabCell, transform);
                var position = new Vector3(x, y, 0);
                instantiate.transform.localPosition = position;
                instantiate.SetPosition(x, y);
                cells[y,x] = instantiate;
            }
        }
    }

    public GridCellView GetCell(Vector2Int position)
    {
        return cells[position.y, position.x];
    }

    public void PlaceInGrid(TetraminoView tetramino)
    {
        for (int i = 0; i < tetramino.Parts.Count; i++)
        {
            AddInGrid(tetramino.Parts[i]);
        }

        if (!game.IsEnded)
        {
            game.NewTetramino();
        }
    }

    public void CheckLines()
    {
        for (int y = Height-1; y >= 0; y--)
        {
            if (IsRowFull(y))
            {
                ClearLine(y);
                Down(y);

                game.UpdateScore();
            }
        }
    }

    private void ResetCells()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                cells[y, x].IsFill = false;
            }
        }
    }

    private void AddInGrid(TetraminoCellView part)
    {
        cells[part.PositionInGrid.y, part.PositionInGrid.x].IsFill = true;

        //сохраняем ссылку на часть тетромино, чтобы потом очистить клетку
        cells[part.PositionInGrid.y, part.PositionInGrid.x].PartOfTetromino = part;
    }

    private bool IsRowFull(int y)
    {
        for (int x = 0; x < Width; x++)
        {
            if (cells[y, x].IsFill == false)
            {
                return false;
            }
        }
        return true;
    }

    private void ClearLine(int y)
    {
        for (int x = 0; x < Width; x++)
        {
            cells[y, x].IsFill = false;
            Cells[y, x].PartOfTetromino.Clear();
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

                    Cells[y-1, x].PartOfTetromino.MoveDownAfterClear();
                }
            }
        }
    }
}
