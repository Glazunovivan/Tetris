using UnityEngine;

public class GridCell : Cell
{
    [SerializeField] private Sprite fillSprite;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    private bool isFill;
    
    public TetraminoCellModel PartOfTetromino { get; set; }

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
