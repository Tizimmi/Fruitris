using UnityEngine;
using Zenject;

public static class PlayerSaveHandler
{
    public const string SaveKey = "PlayerSave";
    
    public static PlayerData LoadPlayerInfo()
    {
        PlayerPrefs.GetString(SaveKey, "Noname");
        PlayerData saveInfo;
        if (PlayerPrefs.HasKey(SaveKey))
        {
            var json = PlayerPrefs.GetString(SaveKey);
            saveInfo = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            saveInfo = new PlayerData("Noname", 0);
        }

        return saveInfo;
    }

    public static void SavePlayerInfo(PlayerData data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(SaveKey, json);
    }
}