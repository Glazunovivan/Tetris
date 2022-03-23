using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private Game game;

    public void Initialize(Game game)
    {
        this.game = game;
        game.OnScoreChanged += UpdateText;
    }

    private void UpdateText(string score)
    {
        scoreText.text = score;
    }

}
