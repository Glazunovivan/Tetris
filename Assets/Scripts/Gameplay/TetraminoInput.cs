using System.Collections.Generic;
using System.Collections;
using UnityEngine;

using Glazunov.Tetris.Model;

[RequireComponent(typeof(TetraminoView))]
public class TetraminoInput : MonoBehaviour
{
    private const int speedDown = 12;
    
    private TetraminoController tetraminoController;
    private bool isBoost;
    private float speed = 1.5f;

    private void Start()
    {
        isBoost = false;
    }

    public void SetTetramino(TetraminoController tetraminoController)
    {
        this.tetraminoController = tetraminoController;

        StartCoroutine(MoveDown());
    }

    private void Update()
    {
        if (tetraminoController != null)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                tetraminoController.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                tetraminoController.MoveRight();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                tetraminoController.Rotate();
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

            if (tetraminoController.IsPlaced())
            {
                StopAllCoroutines();
                enabled = false;
            }
        }
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
            tetraminoController.MoveDown();
        }
    }
}
