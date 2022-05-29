using System.Collections.Generic;
using UnityEngine;

public class TetraminoCellView : MonoBehaviour
{

    [SerializeField] private List<Sprite> _sprites;


    public int CountSprites
    {
        get
        {
            return _sprites.Count;
        }
    }
    public Vector2Int PositionInGrid
    {
        get
        {
            return new Vector2Int(_cell.GridX, _cell.GridY);
        }
    }
    
    private GridView _gridView;
    private TetraminoCell _cell;
    private SpriteRenderer sprite;
    private Animator animator;

    private TetraminoView tetramino;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Создает частичку тетромино
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="center"></param>
    public void Initialize(TetraminoCell cell, GridCell center, GridView gridView)
    {
        _cell = cell;
        _gridView = gridView;
        _cell.OnDown += DrawInGrid;

        _cell.GridX = center.X + _cell.PositionRelativeCenter.x;
        _cell.GridY = center.Y + _cell.PositionRelativeCenter.y;

        sprite = GetComponent<SpriteRenderer>();
        

        tetramino = GetComponentInParent<TetraminoView>();
    }

    public void SetSprite(int index)
    {
        sprite.sprite = _sprites[index];
    }

    public void OnDestroy()
    {
        _cell.OnDown -= DrawInGrid;
    }

    public void DrawInGrid()
    {
        transform.position = _gridView.GetCell(_cell.GridX, _cell.GridY).transform.position;
    }


    public void Clear()
    {
        animator.SetTrigger("Delete");
        tetramino.CheckParts();
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
