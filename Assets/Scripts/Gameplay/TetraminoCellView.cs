using UnityEngine;

public class TetraminoCellView : Cell
{
    [SerializeField] private Vector2Int PositionRelativeCenter;

    private TetraminoView parentTetramino;
    private GridView grid;

    public void Create(GridCellView cell, GridView grid, TetraminoView parentTetramino)
    {
        positionInGrid = cell.PositionInGrid + PositionRelativeCenter;
        this.grid = grid;
        this.parentTetramino = parentTetramino;
    }

    public void MoveLeft()
    {
        positionInGrid += new Vector2Int(-1, 0);
    }

    public void MoveRight()
    {
        positionInGrid += new Vector2Int(1, 0);
    }

    public void MoveDown()
    {
        positionInGrid += new Vector2Int(0, -1);
    }

    public void MoveUp()
    {
        positionInGrid += new Vector2Int(0, 1);
    }

    //90
    public void Rotate()
    {
        positionInGrid += new Vector2Int(PositionRelativeCenter.x * (-1), PositionRelativeCenter.y * (-1));

        if (PositionRelativeCenter.x < 0 || PositionRelativeCenter.x > 0)
        {
            PositionRelativeCenter.x *= -1;
        }
        (PositionRelativeCenter.x, PositionRelativeCenter.y) = (PositionRelativeCenter.y, PositionRelativeCenter.x);

        positionInGrid += new Vector2Int(PositionRelativeCenter.x, PositionRelativeCenter.y);
    }

    //-90
    public void RotateInverse()
    {
        positionInGrid += new Vector2Int(PositionRelativeCenter.x * (-1), PositionRelativeCenter.y * (-1));

        if (PositionRelativeCenter.y < 0 || PositionRelativeCenter.y > 0)
        {
            PositionRelativeCenter.y *= -1;
        }

        (PositionRelativeCenter.x, PositionRelativeCenter.y) = (PositionRelativeCenter.y, PositionRelativeCenter.x);

        positionInGrid += new Vector2Int(PositionRelativeCenter.x, PositionRelativeCenter.y);
    }

    public void MoveDownAfterClear()
    {
        if (parentTetramino != null)
        {
            parentTetramino.MoveDownAfterClear(this);
        }
    }

    public void DrawInGrid()
    {
        transform.position = grid.GetCell(PositionInGrid).transform.position;
    }

    public void Clear()
    {
        parentTetramino.ClearPart(this);
        Destroy(gameObject);
    }
}
