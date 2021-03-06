using System;
using UnityEngine;

public abstract class Tetramino
{
    public bool IsPlaced { get; set; } = false;

    //?????? ??????
    public TetraminoCell[] Parts { get; set; }

    public event Action OnDraw;
    public event Action OnDelete;
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

                //????????, ?????? ?? ???????? ? ?????? ????????????
                if (_grid.Cells[Parts[i].GridY, Parts[i].GridX].IsFill && 
                    _grid.Cells[Parts[i].GridY, Parts[i].GridX].PartOfTetromino != null)
                {
                    return false;
                }
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

    /// <summary>
    /// ??????? ??? ????? ?????????
    /// </summary>
    public void Rotate()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].Rotate();
        }

        if (!IsValidPosition())
        {
            //????? ?? ????? ????????? ?????????
            //?????? ?????????, ???? ??????? ?? ?????? ????????
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

            //?? ?????? ?????????
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
        OnDraw?.Invoke();
    }

    public void Place()
    {
        IsPlaced = true;

        _grid.PlaceTetramino(this);
        _grid.CheckLines();
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
            new TetraminoCell(0,0,this),
            new TetraminoCell(-1,0,this),
            new TetraminoCell(1,0, this),
            new TetraminoCell(2,0,this)
        };
    }
}

public class TetraminoJ : Tetramino
{
    public TetraminoJ() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0,this),
            new TetraminoCell(-1,1,this),
            new TetraminoCell(-1,0,this),
            new TetraminoCell(1,0,this)
        };
    }
}

public class TetraminoL : Tetramino
{
    public TetraminoL() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0,this),
            new TetraminoCell(1,1,this),
            new TetraminoCell(-1,0,this),
            new TetraminoCell(1,0,this)
        };
    }
}

public class TetraminoO : Tetramino
{
    public TetraminoO() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0,this),
            new TetraminoCell(1,1,this),
            new TetraminoCell(0,1,this),
            new TetraminoCell(1,0,this)
        };
    }
}

public class TetraminoS : Tetramino
{
    public TetraminoS() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0,this),
            new TetraminoCell(0,-1,this),
            new TetraminoCell(-1,0,this),
            new TetraminoCell(-1,1,this)
        };
    }
}

public class TetraminoT : Tetramino
{
    public TetraminoT() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0,this),
            new TetraminoCell(-1,0,this),
            new TetraminoCell(1,0,this),
            new TetraminoCell(0,1,this)
        };
    }
}

public class TetraminoZ : Tetramino
{
    public TetraminoZ() : base()
    {
        Parts = new TetraminoCell[4]
        {
            new TetraminoCell(0,0,this),
            new TetraminoCell(0,1,this),
            new TetraminoCell(1,0,this),
            new TetraminoCell(-1,1,this)
        };
    }
}