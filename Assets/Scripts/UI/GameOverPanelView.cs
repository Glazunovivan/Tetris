using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelView : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameOverPanelView panel;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonExit;

    public void Initialize(Game game)
    {
        game.OnGameStarted += ClosePanel;
        game.OnGameOver += ShowPanel;
        game.OnScoreChanged += UpdateScore;

        buttonExit.onClick.AddListener(GameExit);
        buttonRestart.onClick.AddListener(game.StartGame);
        
        panel.gameObject.SetActive(false);
    }

    private void GameExit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ClosePanel()
    {
        panel.gameObject.SetActive(false);
    }

    private void ShowPanel()
    {
        panel.gameObject.SetActive(true);
    }

    private void UpdateScore(string score)
    {
        scoreText.text = score;
    }
}
