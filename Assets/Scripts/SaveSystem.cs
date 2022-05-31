using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem
{
    public static void Save(SaveData data)
    {
        string _path = Application.dataPath + "/SaveData/Save.json";

        if (!File.Exists(_path))
        {
            File.Create(_path);
        }

        var json = JsonUtility.ToJson(data);

        File.WriteAllText(_path, json);
    }

    /// <summary>
    /// Загрузка рекордов
    /// </summary>
    /// <returns></returns>
    public static SaveData Load()
    {
        string json = "";
        string _path = Application.dataPath + "/SaveData/Save.json";

        if (!File.Exists(_path))
        {
            Debug.Log("Файла не существует");
            File.Create(_path);
        }

        if (string.IsNullOrEmpty(json))
        {
            return new SaveData();
        }
        else
        {
            json = File.ReadAllText(_path);
            return JsonUtility.FromJson<SaveData>(json);
        }
    }
}

[Serializable]
public class SaveData
{
    public List<NowScore> scores = new List<NowScore>();

    public void AddScore(uint value)
    {
        scores.Add(new NowScore()
        {
            DateTime = DateTime.Now,
            Score = value
        });
    }
}

[Serializable]
public class NowScore
{
    public DateTime DateTime { get; set; }

    public uint Score { get; set; }
}


