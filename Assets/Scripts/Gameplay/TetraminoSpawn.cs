using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Glazunov.Tetris.Model;
using Glazunov.Tetris.Presenters;

public class TetraminoSpawn : MonoBehaviour
{
    [SerializeField] private TetraminoView[] tetraminoes;

    [SerializeField] private GameObject prefabTetramino;

    private Game game;
    private GridView grid;
    private GridCellView cellStart;

    private TetraminoPresenter tetraminoPresenter;
    private Tetramino tetraminoModel;

    public void Initialize(Game game, GridView grid)
    {
        this.game = game;
        this.grid = grid;

        cellStart = grid.GetCell(new Vector2Int(5, 18));

        game.OnSpawnedTetramino += Spawn;        
    }

    public void Spawn()
    {
        int randTetramino = Random.Range(0, 7);
        
        //сначала создаем модель
        switch (randTetramino)
        {
            case 0:
                tetraminoModel = new TetraminoI();
                break;

            case 1:
                tetraminoModel = new TetraminoJ();
                break;

            case 2:
                tetraminoModel = new TetraminoL();
                break;

            case 3:
                tetraminoModel = new TetraminoO();
                break;

            case 4:
                tetraminoModel = new TetraminoS();
                break;

            case 5:
                tetraminoModel = new TetraminoT();
                break;

            case 6:
                tetraminoModel = new TetraminoZ();
                break;
            default:
                tetraminoModel = new TetraminoJ();
                break;
        }

        //затем объект с View и контроллером
        var instantiate = Instantiate(prefabTetramino, transform);
        instantiate.AddComponent<TetraminoInput>();
        instantiate.GetComponent<TetraminoInput>().SetTetramino(new TetraminoController(tetraminoModel));

        var tetraminoView = instantiate.GetComponent<TetraminoView>();

        //и соединяем
        tetraminoPresenter = new TetraminoPresenter(tetraminoModel, tetraminoView);

        tetraminoModel.Draw();

        Debug.Log("Заспавнили тетромино");

        //TetraminoView tetramino = Instantiate(tetraminoes[randTetramino]);
        //tetramino.Initialize(cellStart, grid, game);
    }


    private void OnDestroy()
    {
        game.OnSpawnedTetramino -= Spawn;
    }
}
