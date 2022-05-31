using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// View тетромино
/// </summary>
public sealed class TetraminoView : MonoBehaviour
{
    public List<TetraminoCellView> Parts
        {
            get
            {
                return parts;
            }
        } 
    
    [SerializeField] private TetraminoCellView prefabPart;

    private Tetramino tetramino;
    private List<TetraminoCellView> parts;
    private GridView gridView;
    private Grid grid;

    public void Initialize(Tetramino tetramino, GridCell center, GridView gridView, Grid grid)
    {
        this.tetramino = tetramino;
        this.tetramino.OnDraw += DrawInGrid;
        this.tetramino.OnDelete += DeleteTetramino;

        this.gridView = gridView;
        this.grid = grid;
        this.grid.OnPlaceTetramino += PlaceInGrid;

        CreateCellsView(center);

        if (!tetramino.IsValidPosition())
        {
            //game.GameOver();
            FindObjectOfType<GameCreator>().Game.GameOver();
            return;
        }

        DrawInGrid();
    }

    public void PlaceInGrid()
    {
        gridView.PlaceTetramino(this);
        this.grid.OnPlaceTetramino -= PlaceInGrid;
    }

    /// <summary>
    /// Создаем дочерние элементы отображения
    /// </summary>
    /// <param name="center"></param>
    private void CreateCellsView(GridCell center)
    {
        int index = Random.Range(0, prefabPart.CountSprites);
        parts = new List<TetraminoCellView>();
        for (int i = 0; i < tetramino.Parts.Length; i++)
        {
            var instantiate = Instantiate(prefabPart, transform);
            instantiate.Initialize(tetramino.Parts[i], center, this.gridView);
            
            instantiate.SetSprite(index);
            parts.Add(instantiate);
        }
    }
    
    private void DrawInGrid()
    {
        transform.position = gridView.GetCell(parts[0].PositionInGrid.x, parts[0].PositionInGrid.y).transform.position;

        for (int i = 0; i < Parts.Count; i++)
        {
            if (Parts[i] != null)
            {
                Parts[i].DrawInGrid();
            }
        }
    }

    private void DeleteTetramino()
    {
        tetramino.OnDraw -= DrawInGrid;
        tetramino.OnDelete -= DeleteTetramino;
        //game.OnGameOver -= DeleteTetramino;

        Destroy(gameObject);
    }

    public void CheckParts()
    {
        if (parts.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
