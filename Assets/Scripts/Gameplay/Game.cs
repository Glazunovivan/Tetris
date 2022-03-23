using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(GameInitializer))]
public class Game : MonoBehaviour
{
    public Score Score { get; private set; }
    public bool IsEnded { get; private set; }

    public event Action OnGameStarted;
    public event Action OnSpawnedTetramino;
    public event Action<string> OnScoreChanged;
    public event Action OnGameOver;

    private GameInitializer gameInitializer;

    void Awake()
    {
        gameInitializer = GetComponent<GameInitializer>();
        gameInitializer.Initialize(this);
        
        StartGame();
    }

    public void StartGame()
    {
        IsEnded = false;
        Score = new Score();
        
        OnGameStarted?.Invoke();
        
        SetZeroScore();
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
        Score.SaveScore();

        StopAllCoroutines();
        
        OnGameOver?.Invoke();
    } 

    public void NewTetramino()
    {
        OnSpawnedTetramino?.Invoke();
    }

    public void GameExit()
    {
        Debug.Log("Вышли в главное меню");
    }

    private void SetZeroScore()
    {
        OnScoreChanged?.Invoke(Score.Count.ToString());
    }
}
