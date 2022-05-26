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
    public Game Game => game;
    
    [SerializeField] private TetraminoCellView prefabPart;

    private Tetramino tetramino;
    private List<TetraminoCellView> parts;
    private GridView gridView;
    private Game game;

    public void Initialize(Tetramino tetramino, GridCell center, GridView gridView)
    {
        this.tetramino = tetramino;
        this.tetramino.OnDraw += DrawInGrid;
        this.tetramino.OnDelete += DeleteTetramino;

        this.gridView = gridView;

        CreateCellsView(center);

        if (!tetramino.IsValidPosition())
        {
            game.GameOver();
        }

        DrawInGrid();
    }
    
    public void MoveDownAfterClear(TetraminoCellView part)
        {
            //part.MoveDown();
            DrawInGrid();
        }
    
    public void ClearPart(TetraminoCellView part)
        {
            parts.Remove(part);
            Destroy(part.gameObject);

            if (Parts.Count == 0)
            {
                DeleteTetramino();
            }
        }

    /// <summary>
    /// Создаем дочерние элементы отображения
    /// </summary>
    /// <param name="center"></param>
    private void CreateCellsView(GridCell center)
    {
        parts = new List<TetraminoCellView>();
        for (int i = 0; i < tetramino.Parts.Length; i++)
        {
            var instantiate = Instantiate(prefabPart, transform);
            instantiate.Initialize(tetramino.Parts[i], center, this.gridView);
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
        game.OnGameOver -= DeleteTetramino;

        Destroy(gameObject);
    }
}
