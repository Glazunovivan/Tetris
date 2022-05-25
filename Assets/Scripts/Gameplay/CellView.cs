using UnityEngine;

public class CellView : MonoBehaviour
{
    [SerializeField] protected Vector2Int positionInGrid;

    public Vector2Int PositionInGrid
    {
        get
        {
            return positionInGrid;
        }
    }
}
