using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button settings;
    [SerializeField] private Button leaderBoard;
    [SerializeField] private Button exit;

    private void Awake()
    {
        startGame.onClick.AddListener(PlayGame);
        settings.onClick.AddListener(OpenSettings);
        leaderBoard.onClick.AddListener(OpenLeaderboard);
        exit.onClick.AddListener(Exit);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    private void OpenSettings()
    {
        Debug.Log("Открыли настройки");
    }

    private void OpenLeaderboard()
    {

    }

    private void Exit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        startGame.onClick.RemoveListener(PlayGame);
        settings.onClick.RemoveListener(OpenSettings);
        leaderBoard.onClick.RemoveListener(OpenLeaderboard);
        exit.onClick.RemoveListener(Exit);
    }
}
