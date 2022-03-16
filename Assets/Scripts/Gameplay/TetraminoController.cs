using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TetraminoController : MonoBehaviour
{
    private Grid grid;
    private Tetramino tetramino;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
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
    }

    private IEnumerator MoveDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            tetramino.MoveDown();
        }
    }
}
