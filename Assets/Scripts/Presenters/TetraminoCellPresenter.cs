using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glazunov.Tetris.Model;

namespace Glazunov.Tetris.Presenters
{
    public class TetraminoCellPresenter
    {
        private TetraminoCellView _view;
        private TetraminoCell _model;

        public TetraminoCellPresenter(TetraminoCellView view, TetraminoCell model)
        {
            _view = view;
            _model = model;
        }
    }
}
