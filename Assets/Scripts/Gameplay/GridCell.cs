public class GridCell
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public bool IsFill { get; set; } = false;

    public TetraminoCell PartOfTetromino = null;

    public GridCell(int x, int y)
    {
        X = x;
        Y = y;
        IsFill = false;
    }

}
