using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Score
{
    public uint Count { get; private set; }

    /// <summary>
    /// Количество очков, на которое увеличиваем счет
    /// </summary>
    private uint addedCount;

    public Score()
    {
        Count = 0;
        addedCount = 10;
    }

    public void AddCount()
    {
        Count += addedCount;
    }

    public void SaveScore()
    {
        //сохраняет счет
    }

}
