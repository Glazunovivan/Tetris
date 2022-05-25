using UnityEngine;

public sealed class Grid : MonoBehaviour
{
    [SerializeField] private GridCell prefabCell;

    private Game game;
    private GridCell[,] cells;
    
    public GridCell[,] Cells
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

        cells = new GridCell[game.Height, game.Width];

        for (int y = 0; y < game.Height; y++)
        {
            for (int x = 0; x < game.Width; x++)
            {
                var inst = Instantiate(prefabCell, gameObject.transform);
                inst.SetPosition(new Vector2Int(x, y));
                inst.transform.localPosition = new Vector3(x, y, 1);

                cells[y, x] = inst;
            }
        }
    }

    public GridCell GetCell(Vector2Int position)
    {
        return cells[position.y, position.x];
    }

    public void PlaceInGrid(Tetramino tetramino)
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
        for (int y = game.Height-1; y >= 0; y--)
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
        for (int y = 0; y < game.Height; y++)
        {
            for (int x = 0; x < game.Width; x++)
            {
                cells[y, x].IsFill = false;
            }
        }
    }

    private void AddInGrid(TetraminoCellModel part)
    {
        cells[part.PositionInGrid.y, part.PositionInGrid.x].IsFill = true;

        //сохраняем ссылку на часть тетромино, чтобы потом очистить клетку
        cells[part.PositionInGrid.y, part.PositionInGrid.x].PartOfTetromino = part;
    }

    private bool IsRowFull(int y)
    {
        for (int x = 0; x < game.Width; x++)
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
        for (int x = 0; x < game.Width; x++)
        {
            cells[y, x].IsFill = false;
            Cells[y, x].PartOfTetromino.Clear();
        }
    }

    private void Down(int i)
    {
        for (int y = i; y < game.Height; y++)
        {
            for (int x = 0; x < game.Width; x++)
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
