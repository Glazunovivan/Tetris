using UnityEngine;

public class TetraminoSpawn : MonoBehaviour
{
    [SerializeField] private TetraminoView prefabTetramino;
    [SerializeField] private GridView gridView;

    private Game _game;
    private Grid _grid;
    private GridCell _cellStart;

    public void Initialize(Game game, Grid grid)
    {
        _game = game;
        _game.OnSpawnedTetramino += Spawn;        
        
        _grid = grid;
        _cellStart = _grid.GetCell(5,18);
    }

    public void Spawn()
    {
        int randTetramino = Random.Range(0, 7);
        
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
            default:
                tetramino = new TetraminoI();
                break;
        }

        tetramino.SetGrid(_grid);

        TetraminoView tetraminoView = Instantiate(prefabTetramino);
        tetraminoView.Initialize(tetramino, _cellStart, gridView);
        tetraminoView.GetComponent<TetraminoController>().SetTetramino(tetramino);
    }

    private void OnDestroy()
    {
        _game.OnSpawnedTetramino -= Spawn;
    }
}
