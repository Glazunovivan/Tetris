using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glazunov.Tetris.Model
{
    public enum TetraminoType
    {
        I, J, L, O, S, T, Z
    }

    public abstract class Tetramino
    {
        public bool IsPlaced { get; set; } = false;
        public TetraminoCell[] Parts;
        public TetraminoController tetraminoController;

        public Vector3 Position = new Vector3(0,0,0);
        
        protected const int countParts = 4;
        protected TetraminoType type;

        public event Action OnDraw;
        public event Action OnPlaced;

        public void Draw() => OnDraw?.Invoke();
        public void Placed() => OnPlaced?.Invoke();
    }

    public class TetraminoI : Tetramino
    {
        public TetraminoI()
        {
            type = TetraminoType.I;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(-1,0),
                new TetraminoCell(1,0),
                new TetraminoCell(2,0)
            }; 
            tetraminoController = new TetraminoController(this);
        }
    }
    
    public class TetraminoJ : Tetramino
    {
        public TetraminoJ()
        {
            type = TetraminoType.J;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(-1,1),
                new TetraminoCell(-1,0),
                new TetraminoCell(1,0)
            };
            tetraminoController = new TetraminoController(this);
        }

    }

    public class TetraminoL : Tetramino
    {
        public TetraminoL()
        {
            type = TetraminoType.L;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(1,1),
                new TetraminoCell(-1,0),
                new TetraminoCell(1,0)
            };
            tetraminoController = new TetraminoController(this);
        }
    }

    public class TetraminoO : Tetramino
    {
        public TetraminoO()
        {
            type = TetraminoType.O;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(1,0),
                new TetraminoCell(1,1),
                new TetraminoCell(0,1)
            };
            tetraminoController = new TetraminoController(this);
        }

    }

    public class TetraminoS : Tetramino
    {
        public TetraminoS()
        {
            type = TetraminoType.S;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(1,1),
                new TetraminoCell(0,1),
                new TetraminoCell(2,1)
            };
            tetraminoController = new TetraminoController(this);
        }
    }

    public class TetraminoT : Tetramino
    {
        public TetraminoT()
        {
            type = TetraminoType.T;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(-1,0),
                new TetraminoCell(1,0),
                new TetraminoCell(0,1)
            };
            tetraminoController = new TetraminoController(this);
        }
    }

    public class TetraminoZ : Tetramino
    {
        public TetraminoZ()
        {
            type = TetraminoType.Z;
            Parts = new TetraminoCell[countParts]
            {
                new TetraminoCell(0,0),
                new TetraminoCell(0,1),
                new TetraminoCell(1,0),
                new TetraminoCell(-1,1)
            };
            tetraminoController = new TetraminoController(this);
        }
    }
}
