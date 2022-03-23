using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Tetramino))]
public class TetraminoController : MonoBehaviour
{
    private Tetramino tetramino;
    private bool isBoost;
    private float speed = 1.5f;

    private void Start()
    {
        isBoost = false;
        tetramino = GetComponent<Tetramino>();  
        StartCoroutine(MoveDown());
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

    private IEnumerator MoveDown()
    {
        while (true)
        {
            if (isBoost)
            {
                yield return new WaitForSeconds(speed / 12);
            }
            else
            {
                yield return new WaitForSeconds(speed);
            }
            tetramino.MoveDown();
        }
    }
}
