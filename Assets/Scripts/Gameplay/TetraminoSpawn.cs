using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glazunov.Tetris.Model;

public class TetraminoSpawn : MonoBehaviour
{
    [SerializeField] private TetraminoView[] tetraminoes;

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

        Tetramino tetramino;
        
        switch (randTetramino)
        {
            case 0:
                tetramino = new TetraminoI();
                break;

            case 1:
                tetramino = new TetraminoJ();
                break;

            case 2:
                tetramino = new TetraminoL();
                break;

            case 3:
                tetramino = new TetraminoO();
                break;

            case 4:
                tetramino = new TetraminoS();
                break;

            case 5:
                tetramino = new TetraminoT();
                break;

            case 6:
                tetramino = new TetraminoZ();
                break;
        }


        //TetraminoView tetramino = Instantiate(tetraminoes[randTetramino]);
        //tetramino.Initialize(cellStart, grid, game);
    }


    private void OnDestroy()
    {
        game.OnSpawnedTetramino -= Spawn;
    }
}
