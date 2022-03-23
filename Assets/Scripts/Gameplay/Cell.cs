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
}
