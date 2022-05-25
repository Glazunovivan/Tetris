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

    public Tetramino()
    {
        IsPlaced = false;
    }

    public bool IsValidPosition()
    {
        return true;
    }

    public void MoveLeft()
    {
        //for (int i = 0; i < Parts.Length; i++)
        //{
        //    Parts[i].MoveLeft();
        //}
        //if (IsValidPosition() == false)
        //{
        //    for (int i = 0; i < Parts.Length; i++)
        //    {
        //        Parts[i].MoveRight();
        //    }
        //}
    }

    public void MoveRight()
    {
        //for (int i = 0; i < Parts.Length; i++)
        //{
        //    Parts[i].MoveRight();
        //}
        //if (IsValidPosition() == false)
        //{
        //    for (int i = 0; i < Parts.Length; i++)
        //    {
        //        Parts[i].MoveLeft();
        //    }
        //}
    }

    public void MoveDown()
    {
        for (int i = 0; i < Parts.Length; i++)
        {
            Parts[i].MoveDown();
        }
        //if (IsValidPosition() == false)
        //{
        //    for (int i = 0; i < Parts.Length; i++)
        //    {
        //        Parts[i].MoveUp();
        //    }
        //    //Place();
        //}
        Debug.Log("Сдвинулись вниз");
        OnDraw?.Invoke();
    }

    public void Rotate()
    {
        //if (type == TetraminoType.O)
        //{
        //    return;
        //}

        //for (int i = 0; i < Parts.Count; i++)
        //{
        //    Parts[i].Rotate();
        //}

        //if (IsValidPosition() == false)
        //{
        //    //на левой половинке находимся
        //    //меняем положения, пока позиция не станет валидной
        //    if (Parts[0].PositionInGrid.x < game.Width / 2)
        //    {
        //        do
        //        {
        //            for (int i = 0; i < Parts.Count; i++)
        //            {
        //                Parts[i].RotateInverse();
        //            }

        //            for (int i = 0; i < Parts.Count; i++)
        //            {
        //                Parts[i].MoveRight();
        //            }

        //            Rotate();

        //        } while (IsValidPosition() != true);
        //    }
        //    //на правой половинке находимся
        //    else if (Parts[0].PositionInGrid.x > game.Width / 2)
        //    {
        //        do
        //        {
        //            for (int i = 0; i < Parts.Count; i++)
        //            {
        //                Parts[i].RotateInverse();
        //            }

        //            for (int i = 0; i < Parts.Count; i++)
        //            {
        //                Parts[i].MoveLeft();
        //            }

        //            Rotate();

        //        } while (IsValidPosition() != true);
        //    }
        //}
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