using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private TetraminoSpawn spawner;
    [SerializeField] private ScoreView scoreView;
    [SerializeField] private GameOverPanelView gameOverPanelView;


    private void OnEnable()
    {
        Game game = new Game();

        grid.Initialize(game);
        spawner.Initialize(game, grid);
        scoreView.Initialize(game);
        gameOverPanelView.Initialize(game);

        game.StartGame();
    }
}
