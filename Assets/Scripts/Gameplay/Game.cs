using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public sealed class Game
{
    public Score Score { get; private set; }
    public bool IsEnded { get; private set; } = false;
    
    public Settings Settings;
    public Grid Grid { get; set; }

    public event Action OnGameStarted;
    public event Action OnSpawnedTetramino;
    public event Action OnGameOver;
    public event Action<string> OnScoreChanged;

    public readonly int Width = 10;
    public readonly int Height = 20;

    public Game()
    {
        Grid = new Grid(Width, Height, this);

        Settings = new Settings();
        Settings.LoadSettings();

        StartGame();
    }

    public void StartGame()
    {
        IsEnded = false;
        Score = new Score();
        SetZeroScore();
        OnGameStarted?.Invoke();

        NewTetramino();
    }

    public void UpdateScore()
    {
        Score.AddCount();
        OnScoreChanged?.Invoke(Score.Count.ToString());
    }

    public void GameOver()
    {
        IsEnded = true;
        SaveSystem.Save(new SaveData(Score.Count));
        
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
