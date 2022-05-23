using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCellPresenter
{
    private GridCell _gridCell;
    private GridCellView _gridCellView;

    public GridCellPresenter(GridCell gridCell, GridCellView gridCellView)
    {
        _gridCell = gridCell;   
        _gridCellView = gridCellView;
    }

    public void DrawInGrid(Vector3 position)
    {
        _gridCellView.Draw(position);
    }
}
