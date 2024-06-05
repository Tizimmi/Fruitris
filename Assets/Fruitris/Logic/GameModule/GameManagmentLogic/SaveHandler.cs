using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveHandler
{
    public static void SavePlayerData(Player player)
    {
        BinaryFormatter formatter = new();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new(path, FileMode.Create);

        PlayerData data = new(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/player.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("file not found in path: " + path);
            return null;
        }
    }
}