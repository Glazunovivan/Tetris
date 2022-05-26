using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tetramino
{
    public bool IsPlaced { get; set; } = false;

    //список частей
    public TetraminoCell[] Parts { get; set; }

    public event Action OnDraw;
    public event Action OnDelete;
    public event Action OnPlaced;
    private Grid _grid;

    public Tetramino()
    {
        IsPlaced = false;
    }

    public void SetGrid(Grid grid)
    {
        _grid = grid;
    }

    public bool IsValidPosition()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            if (Parts[i] != null)
            {
                if (Parts[i].GridX < 0 ||
                    Parts[i].GridX >= _grid.Width ||
                    Parts[i].GridY < 0 ||
                    Parts[i].GridY >= _grid.Height)
                {
                    return false;
                }

                //проверка, занята ли клеточка с такими координатами
                //if (_grid.Cells[Parts[i].GridY, Parts[i].GridX].IsFill)
                //{
                //    return false;
                //}
            }
        }
        return true;
    }

    public void MoveLeft()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].MoveLeft();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < Parts.Length; i++)
            {
                Parts[i].MoveRight();
            }
        }
        OnDraw?.Invoke();
    }

    public void MoveRight()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].MoveRight();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < Parts.Length; i++)
            {
                Parts[i].MoveLeft();
            }
        }
        OnDraw?.Invoke();
    }

    public void MoveDown()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].MoveDown();
        }
        if (IsValidPosition() == false)
        {
            for (int i = 0; i < Parts.Length; i++)
            {
                Parts[i].MoveUp();
            }
            Place();
        }
        OnDraw?.Invoke();
    }

    public void Rotate()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].Rotate();
        }

        if (!IsValidPosition())
        {
            Debug.Log("невалидная позиция");
            //центр на левой половинке находится
            //меняем положения, пока позиция не станет валидной
            if (Parts[0].GridX < _grid.Width / 2)
            {
                do
                {
                    for (int i = 0; i < Parts.Length; i++)
                    {
                        Parts[i].RotateInverse();
                    }

                    for (int i = 0; i < Parts.Length; i++)
                    {
                        Parts[i].MoveRight();
                    }

                    Rotate();

                } while (IsValidPosition() != true);
            }

            //на правой половинке
            else if (Parts[0].GridX > _grid.Width / 2)
            {
                do
                {
                    for (int i = 0; i < Parts.Length; i++)
                    {
                        Parts[i].RotateInverse();
                    }

                    for (int i = 0; i < Parts.Length; i++)
                    {
                        Parts[i].MoveLeft();
                    }

                    Rotate();

                } while (IsValidPosition() != true);
            }
        }

        Debug.Log("Повернулись");
        OnDraw?.Invoke();
    }

    public void Place()
    {
        IsPlaced = true;
        OnPlaced?.Invoke();

        _grid.PlaceTetramino(this);
        _grid.CheckLines();
        //tetramino.IsPlaced = true;
        //gridView.PlaceInGrid(this);
        //gridView.CheckLines();
    }

    public void Delete()
    {
        OnDelete?.Invoke();
    }

}

public class TetraminoI : Tetramino
{
    public TetraminoI() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(-1,0),
            new TetraminoCell(1,0),
            new TetraminoCell(2,0)
        };
    }
}

public class TetraminoJ : Tetramino
{
    public TetraminoJ() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(-1,1),
            new TetraminoCell(-1,0),
            new TetraminoCell(1,0)
        };
    }
}

public class TetraminoL : Tetramino
{
    public TetraminoL() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(1,1),
            new TetraminoCell(-1,0),
            new TetraminoCell(1,0)
        };
    }
}

public class TetraminoO : Tetramino
{
    public TetraminoO() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(1,1),
            new TetraminoCell(0,1),
            new TetraminoCell(1,0)
        };
    }
}

public class TetraminoS : Tetramino
{
    public TetraminoS() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(1,1),
            new TetraminoCell(0,1),
            new TetraminoCell(2,0)
        };
    }
}

public class TetraminoT : Tetramino
{
    public TetraminoT() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(-1,0),
            new TetraminoCell(1,0),
            new TetraminoCell(0,1)
        };
    }
}

public class TetraminoZ : Tetramino
{
    public TetraminoZ() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0),
            new TetraminoCell(0,1),
            new TetraminoCell(1,0),
            new TetraminoCell(-1,1)
        };
    }
}