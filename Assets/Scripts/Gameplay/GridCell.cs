using UnityEngine;

public class GridCell : Cell
{
    public bool IsFill 
    {
        get
        {
            return isFill;
        }
        set
        {
            isFill = value;
            //перекрашиваем
            SetColor();
        }
    }

    private bool isFill;
    public TetraminoCellModel PartOfTetromino { get; set; }

    private void SetColor()
    {
        if (isFill)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1);
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 0.2f);
        }
    }
}
