using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private GridCell[,] cells;

    public readonly int Width = 10;
    public readonly int Height = 20;
    public GridCell[,] Cells
    {
        get
        {
            return cells;
        }
    }

    private void Awake()
    {
        cells = new GridCell[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                cells[y,x] = transform.GetChild(y).GetChild(x).GetComponent<GridCell>();
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
    }

    public void CheckLines()
    {
        for (int y = Height-1; y >= 0; y--)
        {
            if (IsRowFull(y))
            {
                ClearLine(y);
                Down(y);
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
                    //Cells[y, x].IsFill = false;
                    Cells[y, x].IsFill = false;
                    Cells[y, x].PartOfTetromino = null;

                    Cells[y-1, x].PartOfTetromino.MoveDownAfterClear();
                }
            }
        }
    }
}
