using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public sealed class Game
{
    public Score Score { get; private set; }
    public bool IsEnded { get; private set; } = false;
    
    public Settings Settings;

    public event Action OnGameStarted;
    public event Action OnGameRestart;
    public event Action OnSpawnedTetramino;
    public event Action OnGameOver;
    public event Action<string> OnScoreChanged;

    public Game()
    {
        Settings = new Settings();
        Settings.LoadSettings();
    }

    public void StartGame()
    {
        Debug.Log("Старт игры");
        IsEnded = false;
        Score = new Score();
        SetZeroScore();
        OnGameStarted?.Invoke();
        OnSpawnedTetramino?.Invoke();
    }

    public void RestartGame()
    {
        OnGameRestart?.Invoke();
        OnGameStarted?.Invoke();
    }

    public void UpdateScore()
    {
        Score.AddCount();
        OnScoreChanged?.Invoke(Score.Count.ToString());
    }

    public void GameOver()
    {
        IsEnded = true;

        //SaveData sd = SaveSystem.Load();
        //sd.AddScore(Score.Count);
        //SaveSystem.Save(sd);

        OnGameOver?.Invoke();
    } 

    public void NewTetramino()
    {
        OnSpawnedTetramino?.Invoke();
    }

    private void SetZeroScore()
    {
        OnScoreChanged?.Invoke(Score.Count.ToString());
    }
}
