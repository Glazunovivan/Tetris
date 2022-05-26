using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TetraminoView))]
public class TetraminoController : MonoBehaviour
{
    private const int speedDown = 12;
    
    private Tetramino tetramino;
    private bool isBoost;
    private float speed = 1.5f;

    private void Start()
    {
        isBoost = false;
        //speed = tetramino.Game.Settings.Dificult;

        if (tetramino != null)
        {
            StartCoroutine(MoveDown());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tetramino.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tetramino.MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tetramino.Rotate();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isBoost = true;
            StopAllCoroutines();
            StartCoroutine(MoveDown());
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isBoost = false;
            StopAllCoroutines();
            StartCoroutine(MoveDown());
        }

        if (tetramino.IsPlaced)
        {
            StopAllCoroutines();
            enabled = false;
        }
    }

    public void SetTetramino(Tetramino tetramino)
    {
        this.tetramino = tetramino;
    }

    private IEnumerator MoveDown()
    {
        while (true)
        {
            if (isBoost)
            {
                yield return new WaitForSeconds(speed / speedDown);
            }
            else
            {
                yield return new WaitForSeconds(speed);
            }
            tetramino.MoveDown();
        }
    }
}
