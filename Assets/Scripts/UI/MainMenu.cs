using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Панели с меню")]
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelLeaderboard;

    [Header("Префаб рекордов")]
    [SerializeField] private ScoreRecordView prefabScores;
    [SerializeField] private Transform transformScrollList;

    [SerializeField] private Button startGame;
    [SerializeField] private Button settings;
    [SerializeField] private Button leaderBoard;
    [SerializeField] private Button exit;
    [SerializeField] private Button toMenu;
    [SerializeField] private Button toMenu2;

    [SerializeField] private Slider sliderDificult;

    private GameObject currentPanel;

    private void Awake()
    {
        startGame.onClick.AddListener(PlayGame);
        settings.onClick.AddListener(OpenSettings);
        leaderBoard.onClick.AddListener(OpenLeaderboard);
        exit.onClick.AddListener(Exit);
        toMenu.onClick.AddListener(ToMenu);
        toMenu2.onClick.AddListener(ToMenu);
        sliderDificult.onValueChanged.AddListener(ChangeDificult);
        currentPanel = panelMainMenu;
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    private void OpenSettings()
    {
        currentPanel.SetActive(false);
        currentPanel = panelSettings;
        currentPanel.SetActive(true);

        Settings settings = new Settings();
        Dificult dificult = settings.LoadSettings();
        float dif = dificult.Value;

        int value = 1;
        switch (dif)
        {
            case 1.3f:
                value = 1;
                break;
            case 1.0f:
                value = 2;
                break;
            case 0.6f:
                value = 3;
                break;
        }
        sliderDificult.value = value;
    }

    private void OpenLeaderboard()
    {
        for (int i = 0; i < transformScrollList.childCount; i++)
        {
            Destroy(transformScrollList.GetChild(i).GetComponent<ScoreRecordView>().gameObject);
        }

        currentPanel.SetActive(false);
        currentPanel = panelLeaderboard;
        currentPanel.SetActive(true);

        //Score saveData = SaveSystem.Load();

        //if (saveData.Scores.Count != 0)
        //{
        //    foreach (SavedScore sd in saveData.Scores)
        //    {
        //        var inst = Instantiate(prefabScores, transformScrollList);
        //        inst.Initialize(sd);
        //    }
        //}
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void ToMenu()
    {
        currentPanel.SetActive(false);
        currentPanel = panelMainMenu;
        currentPanel.SetActive(true);
    }

    private void OnDestroy()
    {
        startGame.onClick.RemoveListener(PlayGame);
        settings.onClick.RemoveListener(OpenSettings);
        leaderBoard.onClick.RemoveListener(OpenLeaderboard);
        exit.onClick.RemoveListener(Exit);
        toMenu.onClick.RemoveListener(ToMenu);
        toMenu2.onClick.RemoveListener(ToMenu);
        sliderDificult.onValueChanged.RemoveListener(ChangeDificult);
    }

    public void ChangeDificult(float value)
    {
        Settings settings = new Settings();

        settings.Dificult  = new Dificult();

        switch (value) 
        {
            case 1:
                settings.Dificult.Value = 1.3f;
                break;
            case 2:
                settings.Dificult.Value = 1.0f;
                break;
            case 3:
                settings.Dificult.Value = 0.6f;
                break;
        }

        settings.SaveSettings();
    }
}
