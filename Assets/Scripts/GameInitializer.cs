using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GridView gridView;
    [SerializeField] private TetraminoSpawn spawner;
    [SerializeField] private ScoreView scoreView;
    [SerializeField] private GameOverPanelView gameOverPanelView;

    private void OnEnable()
    {
        Game game = new Game();

        gridView.Initialize(game, game.Grid);
        
        spawner.Initialize(game, game.Grid);

        scoreView.Initialize(game);
        gameOverPanelView.Initialize(game);

        game.StartGame();
    }
}
