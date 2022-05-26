using UnityEngine;

public class TetraminoCellView : MonoBehaviour
{
    private GridView _gridView;
    private TetraminoCell _cell;

    public Vector2Int PositionInGrid
    {
        get
        {
            return new Vector2Int(_cell.GridX, _cell.GridY);
        }
    }

    /// <summary>
    /// Создает частичку тетромино
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="center"></param>
    public void Initialize(TetraminoCell cell, GridCell center, GridView gridView)
    {
        _cell = cell;
        _gridView = gridView;

        _cell.GridX = center.X + _cell.PositionRelativeCenter.x;
        _cell.GridY = center.Y + _cell.PositionRelativeCenter.y;
    }

    public void DrawInGrid()
    {
        transform.position = _gridView.GetCell(_cell.GridX, _cell.GridY).transform.position;
    }

    //90
    public void Rotate()
    {
        //positionInGrid += new Vector2Int(_cell.PositionRelativeCenter.x * (-1), _cell.PositionRelativeCenter.y * (-1));

        //if (_cell.PositionRelativeCenter.x < 0 || _cell.PositionRelativeCenter.x > 0)
        //{
        //    _cell.PositionRelativeCenter.x *= -1;
        //}
        //(_cell.PositionRelativeCenter.x, _cell.PositionRelativeCenter.y) = (_cell.PositionRelativeCenter.y, _cell.PositionRelativeCenter.x);

        //positionInGrid += new Vector2Int(_cell.PositionRelativeCenter.x, _cell.PositionRelativeCenter.y);
    }

    //-90
    public void RotateInverse()
    {
        //positionInGrid += new Vector2Int(_cell.PositionRelativeCenter.x * (-1), _cell.PositionRelativeCenter.y * (-1));

        //if (_cell.PositionRelativeCenter.y < 0 || _cell.PositionRelativeCenter.y > 0)
        //{
        //    _cell.PositionRelativeCenter.y *= -1;
        //}

        //(_cell.PositionRelativeCenter.x, _cell.PositionRelativeCenter.y) = (_cell.PositionRelativeCenter.y, _cell.PositionRelativeCenter.x);

        //positionInGrid += new Vector2Int(_cell.PositionRelativeCenter.x, _cell.PositionRelativeCenter.y);
    }

    public void MoveDownAfterClear()
    {
        //if (parentTetramino != null)
        //{
        //    parentTetramino.MoveDownAfterClear(this);
        //}
    }

    public void Clear()
    {
        //parentTetramino.ClearPart(this);
        Destroy(gameObject);
    }
}
