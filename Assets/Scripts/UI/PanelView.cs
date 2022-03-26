using UnityEngine;

public class PanelView : MonoBehaviour
{
    [SerializeField] private GameOverPanelView gameOver;

    public void Initialize(Game game)
    {
        gameOver.Initialize(game);
    }
}
