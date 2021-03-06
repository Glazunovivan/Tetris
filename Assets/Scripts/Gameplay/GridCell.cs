public class GridCell
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public bool IsFill { get; set; } = false;
    public TetraminoCell PartOfTetromino { get; set; } = null;

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
        IsFill = false;
    }

    public void Clear()
    {
        IsFill = false;
        PartOfTetromino = null;
    }
}
