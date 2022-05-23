using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] protected Vector2Int positionInGrid;

    public Vector2Int PositionInGrid
    {
        get
        {
            return positionInGrid;
        }
    }

    public void Create(int x, int y)
    {
        positionInGrid.x = x;
        positionInGrid.y = y;
    }
}
