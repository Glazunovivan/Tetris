using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraminoSpawn : MonoBehaviour
{
    [SerializeField] private Tetramino tetramino;
    [SerializeField] private Cell cell;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        tetramino.Initialize(cell);
    }
}
