using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Vector2Int positionModel;

    public Vector2Int PositionModel
    {
        get
        {
            return positionModel;
        }
    }
}
