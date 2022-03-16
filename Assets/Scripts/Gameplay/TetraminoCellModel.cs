using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraminoCellModel : MonoBehaviour
{
    [SerializeField] private Vector2Int PositionRelativeCenter;
    private Vector2Int positionInGrid;

    public Vector2Int PositionInGrid
    {
        get
        {
            return positionInGrid;
        }
    }

    public void Initialize(Cell cell)
    {
        positionInGrid = cell.PositionModel + PositionRelativeCenter;
        Debug.Log($"{positionInGrid}");
    }

    public void MoveLeft()
    {
        positionInGrid += new Vector2Int(-1, 0);
        Debug.Log($"{positionInGrid}");
    }

    public void MoveRight()
    {
        positionInGrid += new Vector2Int(1, 0);
        Debug.Log($"{positionInGrid}");
    }

    public void MoveDown()
    {
        positionInGrid += new Vector2Int(0, -1);
        Debug.Log($"{positionInGrid}");
    }

    public void MoveUp()
    {
        positionInGrid += new Vector2Int(0, 1);
        Debug.Log($"{positionInGrid}");
    }

    public void Rotate()
    {
        positionInGrid = new Vector2Int(PositionInGrid.x + PositionRelativeCenter.x, positionInGrid.y + PositionRelativeCenter.y);
    }

}
