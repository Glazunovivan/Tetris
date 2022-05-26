using UnityEngine;

public class GameCreator : MonoBehaviour
{
    [SerializeField] private GridView gridView;
    [SerializeField] private TetraminoSpawn spawner;
    [SerializeField] private ScoreView scoreView;
    [SerializeField] private GameOverPanelView gameOverPanelView;

    private Game _game;
    private Grid _grid;

    private void Start()
    {
        _game = new Game();
        _grid = new Grid(10,20, _game);

        gridView.Initialize(_game, _grid);
        spawner.Initialize(_game, _grid);
        scoreView.Initialize(_game);
        gameOverPanelView.Initialize(_game);

        _game.StartGame();
        _game.NewTetramino();
    }
}
