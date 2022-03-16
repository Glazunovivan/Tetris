using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public readonly int Width = 10;
    public readonly int Height = 20;

    [SerializeField] private Cell[] cells;
    
    //Для отрисовки объекта
    public Vector2 GetCellPosition(Vector2Int positionInGrid)
    {
        for(int i = 0; i < cells.Length; i++)
        {
            if (cells[i].PositionModel == positionInGrid)
            {
                return new Vector2(cells[i].transform.position.x, cells[i].transform.position.y);
            }
        }
        return new Vector2(0,0);
    }
}
