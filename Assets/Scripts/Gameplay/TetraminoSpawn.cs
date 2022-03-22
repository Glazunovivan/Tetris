using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TetraminoSpawn : MonoBehaviour
{
    [SerializeField] private Tetramino[] tetraminoes;
    
    private GridCell cell;
    private Grid grid;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        cell = grid.GetCell(new Vector2Int(5,18));
        Spawn();
    }


    public void Spawn()
    {
        int randTetramino = Random.RandomRange(0, tetraminoes.Length);
        Tetramino tetramino = Instantiate(tetraminoes[randTetramino]);
        tetramino.Initialize(cell, grid, this);
    }
}
