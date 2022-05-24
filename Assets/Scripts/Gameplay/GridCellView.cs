using UnityEngine;

public class GridCellView : Cell
{
    [SerializeField] private Sprite fillSprite;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    private bool isFill;
    
    public TetraminoCellView PartOfTetromino { get; set; }

    public void SetPosition(int x, int y)
    {
        positionInGrid = new Vector2Int(x, y);
    }

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

    private void SetColor()
    {
        if (isFill)
        {
            spriteRenderer.sprite = fillSprite;
            
        }
        else
        {
            spriteRenderer.sprite = baseSprite;
        }
    }
}
