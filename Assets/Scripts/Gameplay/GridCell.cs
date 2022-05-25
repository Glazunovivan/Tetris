using UnityEngine;

public class GridCell : Cell
{
    [SerializeField] private Sprite fillSprite;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    private bool isFill;
    
    public TetraminoCellModel PartOfTetromino { get; set; }

    public void SetPosition(Vector2Int position)
    {
        positionInGrid.x = position.x;
        positionInGrid.y = position.y;
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
            spriteRenderer.sprite = baseSprite;
            
        }
        else
        {
            spriteRenderer.sprite = fillSprite;
        }
    }
}
