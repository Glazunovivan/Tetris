using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraminoSpawn : MonoBehaviour
{
    [SerializeField] private Tetramino[] tetraminoes;

    private Game game;
    private GridView grid;
    private GridCellView cellStart;

    public void Initialize(Game game, GridView grid)
    {
        this.game = game;
        this.grid = grid;

        cellStart = grid.GetCell(new Vector2Int(5, 18));

        game.OnSpawnedTetramino += Spawn;        
    }

    public void Spawn()
    {
        int randTetramino = Random.Range(0, tetraminoes.Length);
        Tetramino tetramino = Instantiate(tetraminoes[randTetramino]);
        tetramino.Initialize(cellStart, grid, game);
    }

    private void OnDestroy()
    {
        game.OnSpawnedTetramino -= Spawn;
    }
}
