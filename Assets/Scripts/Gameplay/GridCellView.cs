using UnityEngine;

public class GridCellView : MonoBehaviour
{
    [SerializeField] private Sprite fillSprite;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GridCell cell;

    public TetraminoCellView PartOfTetromino { get; set; }

    public bool IsFill
    {
        get
        {
            return cell.IsFill;
        }
        set
        {
            cell.IsFill = value;
            SetColor();
        }
    }

    public void Initialize(GridCell cell)
    {
        this.cell = cell;
    }

    private void SetColor()
    {
        if (cell.IsFill)
        {
            spriteRenderer.sprite = baseSprite;
        }
        else
        {
            spriteRenderer.sprite = fillSprite;
        }
    }
}
