using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glazunov.Tetris.Model
{
    public class TetraminoController
    {
        private Tetramino tetramino;

        public TetraminoController(Tetramino tetramino)
        {
            this.tetramino = tetramino; 
        }

        public void MoveLeft()
        {
            for (int i = 0; i < tetramino.Parts.Length; i++)
            {
                tetramino.Parts[i].X += -1;
                tetramino.Parts[i].Y += 0;
            }
        }

        public void MoveRight()
        {
            for (int i = 0; i < tetramino.Parts.Length; i++)
            {
                tetramino.Parts[i].X += 1;
                tetramino.Parts[i].Y += 0;
            }
        }

        public void MoveDown()
        {
            for (int i = 0; i < tetramino.Parts.Length; i++)
            {
                tetramino.Parts[i].X += 0;
                tetramino.Parts[i].Y += -1;
            }
        }

        public void MoveUp()
        {
            for (int i = 0; i < tetramino.Parts.Length; i++)
            {
                tetramino.Parts[i].X += 0;
                tetramino.Parts[i].Y += 1;
            }
        }

        //90
        public void Rotate()
        {
            for (int i = 0; i < tetramino.Parts.Length; i++)
            {
                tetramino.Parts[i].X  *= (-1);
                tetramino.Parts[i].Y *= (-1);

                if (tetramino.Parts[i].X < 0 || tetramino.Parts[i].X > 0)
                {
                    tetramino.Parts[i].X *= -1;
                }
                (tetramino.Parts[i].X, tetramino.Parts[i].Y) = (tetramino.Parts[i].Y, tetramino.Parts[i].X);

                tetramino.Parts[i].X += tetramino.Parts[i].X;
                tetramino.Parts[i].Y += tetramino.Parts[i].Y;
            }

            
        }

        //-90
        public void RotateInverse()
        {
            for (int i = 0; i < tetramino.Parts.Length; i++)
            {
                tetramino.Parts[i].X *= (-1);
                tetramino.Parts[i].Y *= (-1);

                if (tetramino.Parts[i].Y < 0 || tetramino.Parts[i].Y > 0)
                {
                    tetramino.Parts[i].Y *= -1;
                }

                (tetramino.Parts[i].X, tetramino.Parts[i].Y) = (tetramino.Parts[i].Y, tetramino.Parts[i].X);

                tetramino.Parts[i].X += tetramino.Parts[i].X;
                tetramino.Parts[i].Y += tetramino.Parts[i].Y;
            }
        }

        public bool IsPlaced()
        {
            return tetramino.IsPlaced;
        }
    }
}
