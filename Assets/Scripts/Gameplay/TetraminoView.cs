using System.Collections.Generic;
using UnityEngine;

//View тетромино
public sealed class TetraminoView : MonoBehaviour
{
    private Tetramino tetramino;

    public List<TetraminoCellView> Parts
        {
            get
            {
                return parts;
            }
        } 

    [SerializeField] private List<TetraminoCellView> parts;

    [SerializeField] private TetraminoCellView prefabPart;

    private GridView gridView;
    private Game game;
    public Game Game => game;

    public void Initialize(Tetramino tetramino, GridCell center, GridView gridView)
    {
        this.tetramino = tetramino;
        this.tetramino.OnDraw += DrawInGrid;
        this.gridView = gridView;
        
        for (int i = 0; i < tetramino.Parts.Length; i++)
        {
            var instantiate = Instantiate(prefabPart, transform);
            instantiate.Initialize(tetramino.Parts[i], center, this.gridView);
            parts.Add(instantiate);
        }

        DrawInGrid();
    }

    public void Initialize(GridCellView cell, GridView grid, Game game)
    {
        tetramino.IsPlaced = false;
        this.gridView = grid;
        this.game = game;
    
        game.OnGameOver += DeleteTetramino;
        for (int i = 0; i < Parts.Count; i++)
        {
            //Parts[i].Create(cell, grid, this);
        }
    
        if (IsValidPosition() == false)
            {
                game.GameOver();
            }
    
        DrawInGrid();
    }
    
    public void MoveLeft()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].MoveLeft();
            }
            if (IsValidPosition() == false)
            {
                for (int i = 0; i < Parts.Count; i++)
                {
                    Parts[i].MoveRight();
                }
            }
            DrawInGrid();
        }
    
    public void MoveRight()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].MoveRight();
            }
            if (IsValidPosition() == false)
            {
                for (int i = 0; i < Parts.Count; i++)
                {
                    Parts[i].MoveLeft();
                }
            }
            DrawInGrid();
        }
    
    public void MoveDown()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].MoveDown();
            }
            if (IsValidPosition() == false)
            {
                for (int i = 0; i < Parts.Count; i++)
                {
                    Parts[i].MoveUp();
                }
                Place();
            }
            DrawInGrid();
        }
    
    public void MoveDownAfterClear(TetraminoCellView part)
        {
            part.MoveDown();
            DrawInGrid();
        }
    
    public void Rotate()
        {
            //if (type == TetraminoType.O)
            //{
            //    return;
            //}

            for (int i = 0; i < Parts.Count; i++)
            {
                Parts[i].Rotate();
            }

            if (IsValidPosition() == false)
            {
                //на левой половинке находимся
                //меняем положения, пока позиция не станет валидной
                if (Parts[0].PositionInGrid.x < game.Width / 2)
                {
                    do
                    {
                        for (int i = 0; i < Parts.Count; i++)
                        {
                            Parts[i].RotateInverse();
                        }

                        for (int i = 0; i < Parts.Count; i++)
                        {
                            Parts[i].MoveRight();
                        }

                        Rotate();

                    } while (IsValidPosition() != true);
                }
                //на правой половинке находимся
                else if (Parts[0].PositionInGrid.x > game.Width / 2)
                {
                    do
                    {
                        for (int i = 0; i < Parts.Count; i++)
                        {
                            Parts[i].RotateInverse();
                        }

                        for (int i = 0; i < Parts.Count; i++)
                        {
                            Parts[i].MoveLeft();
                        }

                        Rotate();

                    } while (IsValidPosition() != true);
                }
            }

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
    
    private bool IsValidPosition()
        {
            for (int i = 0; i < Parts.Count; i++)
            {
                if (Parts[i] != null)
                {
                    if (Parts[i].PositionInGrid.x < 0 ||
                        Parts[i].PositionInGrid.x >= game.Width ||
                        Parts[i].PositionInGrid.y < 0 ||
                        Parts[i].PositionInGrid.y >= game.Height)
                    {
                        return false;
                    }

                    //проверка, занята ли клеточка с такими координатами
                    //if (grid.Cells[Parts[i].PositionInGrid.y, Parts[i].PositionInGrid.x].IsFill)
                    //{
                    //    return false;
                    //}
                }
            }
            return true;
        }
    
    private void DrawInGrid()
    {
        //transform.position = Parts[0].transform.position; //Parts[0].transform.position;
        //_gridView.GetCell(_cell.GridX, _cell.GridY).transform.position
        for (int i = 0; i < Parts.Count; i++)
        {
            if (Parts[i] != null)
            {
                Parts[i].DrawInGrid();
            }
        }
    }
    
    private void Place()
    {
        tetramino.IsPlaced = true;
        gridView.PlaceInGrid(this);
        gridView.CheckLines();
    }

    private void DeleteTetramino()
    {
        game.OnGameOver -= DeleteTetramino;
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        tetramino.OnDraw -= DrawInGrid;
    }
}
