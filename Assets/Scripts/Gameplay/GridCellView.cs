using UnityEngine;

public class GridCellView : MonoBehaviour
{
    [SerializeField] private Sprite fillSprite;
    [SerializeField] private Sprite baseSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private GridCell cell;

    public TetraminoCellView PartOfTetromino
    {
        get
        {
            return partOfTetramino;
        }
        set
        {
            partOfTetramino = value;
        }
    }

    [SerializeField] private TetraminoCellView partOfTetramino;

    public void OnEnable()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(GridCell cell)
    {
        this.cell = cell;
    }

    public void SetColor()
    {
        if (cell.IsFill)
        {
            spriteRenderer.sprite = fillSprite;
        }
        else
        {
            spriteRenderer.sprite = baseSprite;
        }
    }
}
