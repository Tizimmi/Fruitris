using System;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardSaveHandler
{
    const string SaveKey = "LeaderboardSave";
    public static SaveData Load()
    {
        PlayerPrefs.GetString(SaveKey, "default");
        SaveData saveInfo;
        if (PlayerPrefs.HasKey(SaveKey))
        {
            var json = PlayerPrefs.GetString(SaveKey);
            saveInfo = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveInfo = new SaveData();
        }

        return saveInfo;
    }

    public static void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, json);
    }

    public static void Test()
    {
        var SaveData = new SaveData();
        SaveData.PlayerData = new List<PlayerData>()
        {
            new("123", 123),
            new("1233R1AS", 123),
            new("1233R1ASS", 123),
            new("1233R1AAASDASDS", 123),
            new("1QWDASVFC233R1AS", 123)
        };

        var json = JsonUtility.ToJson(SaveData);
        Debug.Log(json);

        var data = JsonUtility.FromJson<SaveData>(json);
    }

    [Serializable]
    public class SaveData
    {
        public List<PlayerData> PlayerData = new();
    }

}