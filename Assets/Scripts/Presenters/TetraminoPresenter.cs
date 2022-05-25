using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Glazunov.Tetris.Model;

namespace Glazunov.Tetris.Presenters
{
    public class TetraminoPresenter
    {
        private TetraminoView _view;
        private Tetramino _model;

        public TetraminoPresenter(Tetramino model, TetraminoView view)
        {
            _view = view;
            _model = model; 
        }

        public void Enable()
        {
            _model.OnDraw += Draw;
            _model.OnPlaced += Disable;
        }

        public void Draw()
        {
            _view.DrawInGrid(_model.Position);
        }

        public void Disable()
        {

        }
    }
}
