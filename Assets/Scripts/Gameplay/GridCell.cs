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

    private void Start()
    {
        
    }

    private void SetColor()
    {
        if (isFill)
        {
            spriteRenderer.color = new Color(0.1f, 0.1f, 0.1f, 1);
        }
        else
        {
            spriteRenderer.color = new Color(0.1f, 0.1f, 0.1f, 0.2f);
        }
    }
}
